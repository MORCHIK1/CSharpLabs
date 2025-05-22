using System;
using System.Reflection;

namespace GenealogySimulator
{
  [Couple("Girl", 0.7, "GenealogySimulator.SmartGirl")]
  [Couple("PrettyGirl", 1.0, "GenealogySimulator.PrettyGirl")]
  [Couple("SmartGirl", 0.8, "GenealogySimulator.Book")]
  public class Botan : Human
  {
    public Botan(string name) : base(name) { Gender = Gender.Male; }
    public Botan() : base(GenerateUniqueName(typeof(Botan))) { Gender = Gender.Male; }
  }
}