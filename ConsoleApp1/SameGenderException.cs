using System;

namespace GenealogySimulator
{
  public class SameGenderException : Exception
  {
    public SameGenderException(string message) : base(message) { }
  }
}