using System;
using System.Reflection;

namespace GenealogySimulator
{
  [Couple("Girl", 0.7, "GenealogySimulator.Girl")]
  [Couple("PrettyGirl", 1.0, "GenealogySimulator.PrettyGirl")]
  [Couple("SmartGirl", 0.5, "GenealogySimulator.Girl")]
  public class Student : Human
  {
    public Student(string name) : base(name) { Gender = Gender.Male; }
    public Student() : base(GenerateUniqueName(typeof(Student))) { Gender = Gender.Male; }
  }
}