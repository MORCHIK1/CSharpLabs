using System;

namespace GenealogySimulator
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  public class CoupleAttribute : Attribute
  {
    public string Pair { get; }
    public double Probability { get; }
    public string ChildType { get; }

    public CoupleAttribute(string pair, double probability, string childType)
    {
      Pair = pair;
      Probability = probability;
      ChildType = childType;
    }
  }
}