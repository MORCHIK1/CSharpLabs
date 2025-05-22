using System;
using System.Collections.Generic;
using System.Reflection;

namespace GenealogySimulator
{
  public abstract class Human : IHasName
  {
    private static readonly Dictionary<Type, int> NameCounters = new Dictionary<Type, int>();
    protected static string GenerateUniqueName(Type type)
    {
      lock (NameCounters)
      {
        if (!NameCounters.ContainsKey(type))
        {
          NameCounters[type] = 0;
        }
        NameCounters[type]++;
        return $"{type.Name}{NameCounters[type]}";
      }
    }

    public string Name { get; protected set; }
    public Gender Gender { get; protected set; }
    public string Patronymic { get; set; }

    protected Human(string name)
    {
      Name = name;
      Patronymic = string.Empty;
    }

    protected Human() : this(GenerateUniqueName(MethodBase.GetCurrentMethod().DeclaringType))
    {
    }

    public override string ToString()
    {
      return $"{GetType().Name} {Name}" + (string.IsNullOrEmpty(Patronymic) ? "" : $" {Patronymic}");
    }
  }
}