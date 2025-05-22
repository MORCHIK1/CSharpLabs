using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

public class MatrixMultiplier
{
  public static async Task<Matrix?> MultiplyAsync(Matrix a, Matrix b, CancellationToken cancellationToken)
  {
    if (a.Columns != b.Rows)
    {
      Console.WriteLine("Cannot multiply matrices: columns of A must equal rows of B.");
      return null;
    }

    var resultMatrix = new Matrix(a.Rows, b.Columns);
    int commonDim = a.Columns;

    var options = new ExecutionDataflowBlockOptions
    {
      MaxDegreeOfParallelism = Environment.ProcessorCount,
      CancellationToken = cancellationToken
    };

    var calculatorBlock = new TransformBlock<(int row, int col), (int row, int col, double value)>(
        async coords =>
        {
          if (cancellationToken.IsCancellationRequested)
          {
            cancellationToken.ThrowIfCancellationRequested();
          }

          double sum = 0;
          for (int k = 0; k < commonDim; k++)
          {
            if (k % 100 == 0)
            {
              if (cancellationToken.IsCancellationRequested)
              {
                cancellationToken.ThrowIfCancellationRequested();
              }
            }
            sum += a[coords.row, k] * b[k, coords.col];
          }
          return (coords.row, coords.col, sum);
        }, options);

    var storeBlock = new ActionBlock<(int row, int col, double value)>(
        resultData =>
        {
          if (cancellationToken.IsCancellationRequested)
          {
            cancellationToken.ThrowIfCancellationRequested();
          }
          resultMatrix[resultData.row, resultData.col] = resultData.value;
        }, options);

    var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };
    calculatorBlock.LinkTo(storeBlock, linkOptions);

    Console.WriteLine($"Posting {a.Rows * b.Columns} element calculation tasks...");
    for (int i = 0; i < a.Rows; i++)
    {
      for (int j = 0; j < b.Columns; j++)
      {
        if (cancellationToken.IsCancellationRequested)
        {
          Console.WriteLine("Cancellation requested during task posting.");
          calculatorBlock.Complete();
          goto end_posting;
        }
        await calculatorBlock.SendAsync((i, j), cancellationToken);
      }
    }
  end_posting:;

    if (!cancellationToken.IsCancellationRequested)
    {
      Console.WriteLine("All tasks posted. Signaling completion of calculator block.");
      calculatorBlock.Complete();
    }

    try
    {
      Console.WriteLine("Waiting for store block to complete...");
      await storeBlock.Completion;
      Console.WriteLine("Store block completed.");
      if (cancellationToken.IsCancellationRequested)
      {
        Console.WriteLine("Operation was cancelled. Result matrix might be incomplete.");
        return null;
      }
      return resultMatrix;
    }
    catch (OperationCanceledException)
    {
      Console.WriteLine("Matrix multiplication was cancelled.");
      return null;
    }
    catch (Exception ex)
    {
      Console.WriteLine($"An error occurred during dataflow processing: {ex.Message}");
      return null;
    }
  }
}