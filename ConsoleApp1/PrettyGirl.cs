using System;
using System.Reflection;

namespace GenealogySimulator
{
  [Couple("Student", 0.4, "Irrelevant")]
  [Couple("Botan", 0.1, "Irrelevant")]
  public class PrettyGirl : Human
  {
    public PrettyGirl(string name) : base(name) { Gender = Gender.Female; }
    public PrettyGirl() : base(GenerateUniqueName(typeof(PrettyGirl))) { Gender = Gender.Female; }
  }
}