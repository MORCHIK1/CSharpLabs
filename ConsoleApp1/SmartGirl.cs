using System;
using System.Reflection;

namespace GenealogySimulator
{
  [Couple("Student", 0.2, "Irrelevant")]
  [Couple("Botan", 0.5, "Irrelevant")]
  public class SmartGirl : Human
  {
    public SmartGirl(string name) : base(name) { Gender = Gender.Female; }
    public SmartGirl() : base(GenerateUniqueName(typeof(SmartGirl))) { Gender = Gender.Female; }
  }
}