using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
  public static async Task Main(string[] args)
  {
    Console.WriteLine("Matrix Multiplication using TPL Dataflow");
    Console.WriteLine("Press ESC to cancel the operation at any time.");
    Console.WriteLine("------------------------------------------");

    Matrix a = Matrix.GenerateRandom(50, 30, seed: 1);
    Matrix b = Matrix.GenerateRandom(30, 60, seed: 2);

    a.Print(5, 5, "Matrix A (partial)");
    b.Print(5, 5, "Matrix B (partial)");

    var cts = new CancellationTokenSource();

    var cancellationListener = Task.Run(() =>
    {
      Console.WriteLine("\nPress ESC to cancel...");
      while (!cts.IsCancellationRequested)
      {
        if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape)
        {
          Console.WriteLine("\nESC pressed. Requesting cancellation...");
          cts.Cancel();
          break;
        }
        Thread.Sleep(100);
      }
    });

    Stopwatch stopwatch = Stopwatch.StartNew();
    Matrix? result = await MatrixMultiplier.MultiplyAsync(a, b, cts.Token);
    stopwatch.Stop();

    if (result != null)
    {
      Console.WriteLine($"\nMultiplication completed in {stopwatch.ElapsedMilliseconds} ms.");
      result.Print(10, 10, "Result Matrix C (partial)");
    }
    else
    {
      Console.WriteLine($"\nMultiplication did not complete or was cancelled. Time elapsed: {stopwatch.ElapsedMilliseconds} ms.");
    }

    if (!cancellationListener.IsCompleted)
    {
      if (!cts.IsCancellationRequested) cts.Cancel();
      await cancellationListener;
    }
    Console.WriteLine("Program finished. Press any key to exit.");
    Console.ReadKey();
  }
}