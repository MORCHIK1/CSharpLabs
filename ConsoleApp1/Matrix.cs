using System;

public class Matrix
{
  public int Rows { get; }
  public int Columns { get; }
  private readonly double[,] _data;

  public Matrix(int rows, int columns)
  {
    if (rows <= 0 || columns <= 0)
      throw new ArgumentOutOfRangeException(nameof(rows), "Matrix dimensions must be positive.");
    Rows = rows;
    Columns = columns;
    _data = new double[rows, columns];
  }

  public double this[int row, int col]
  {
    get => _data[row, col];
    set => _data[row, col] = value;
  }

  public static Matrix GenerateRandom(int rows, int columns, int seed = 0)
  {
    var matrix = new Matrix(rows, columns);
    var random = seed == 0 ? new Random() : new Random(seed);
    for (int i = 0; i < rows; i++)
    {
      for (int j = 0; j < columns; j++)
      {
        matrix[i, j] = random.Next(1, 11);
      }
    }
    return matrix;
  }

  public void Print(int maxRows = 10, int maxCols = 10, string title = "Matrix")
  {
    Console.WriteLine($"\n{title} ({Rows}x{Columns}):");
    for (int i = 0; i < Math.Min(Rows, maxRows); i++)
    {
      for (int j = 0; j < Math.Min(Columns, maxCols); j++)
      {
        Console.Write($"{this[i, j],8:F2} ");
      }
      if (Columns > maxCols) Console.Write("...");
      Console.WriteLine();
    }
    if (Rows > maxRows) Console.WriteLine("...");
  }
}