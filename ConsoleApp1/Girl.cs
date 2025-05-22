using System;
using System.Reflection;

namespace GenealogySimulator
{
  [Couple("Student", 0.7, "Irrelevant")]
  [Couple("Botan", 0.3, "Irrelevant")]
  public class Girl : Human
  {
    public Girl(string name) : base(name) { Gender = Gender.Female; }
    public Girl() : base(GenerateUniqueName(typeof(Girl))) { Gender = Gender.Female; }
  }
}