using System;

namespace GenealogySimulator
{
  public class Book : IHasName
  {
    public string Name { get; private set; }

    public Book(string name)
    {
      Name = name;
    }
    public Book() : this($"Book{Guid.NewGuid().ToString().Substring(0, 4)}") { }

    public override string ToString()
    {
      return $"Book {Name}";
    }
  }
}