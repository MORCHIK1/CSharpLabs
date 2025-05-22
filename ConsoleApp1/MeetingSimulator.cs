using System;
using System.Linq;
using System.Reflection;

namespace GenealogySimulator
{
  public static class MeetingSimulator
  {
    private static readonly Random Rand = new Random();

    public static IHasName Couple(Human person1, Human person2)
    {
      Console.WriteLine($"\nЗустріч: {person1} ({person1.GetType().Name}) та {person2} ({person2.GetType().Name})");

      if (person1.Gender == person2.Gender)
      {
        throw new SameGenderException($"Зустріч осіб однакової статі неможлива: {person1.Name} та {person2.Name}.");
      }

      var attrP1 = person1.GetType().GetCustomAttributes<CoupleAttribute>(false)
          .FirstOrDefault(attr => attr.Pair == person2.GetType().Name);

      bool p1LikesP2 = false;
      if (attrP1 != null)
      {
        p1LikesP2 = Rand.NextDouble() < attrP1.Probability;
        Console.WriteLine($"{person1.Name} {(p1LikesP2 ? "сподобався(лась)" : "не сподобався(лась)")} {person2.Name} (Імовірність: {attrP1.Probability * 100}%)");
      }
      else
      {
        Console.WriteLine($"{person1.Name} не має визначених почуттів до {person2.GetType().Name}.");
      }

      var attrP2 = person2.GetType().GetCustomAttributes<CoupleAttribute>(false)
          .FirstOrDefault(attr => attr.Pair == person1.GetType().Name);

      bool p2LikesP1 = false;
      if (attrP2 != null)
      {
        p2LikesP1 = Rand.NextDouble() < attrP2.Probability;
        Console.WriteLine($"{person2.Name} {(p2LikesP1 ? "сподобався(лась)" : "не сподобався(лась)")} {person1.Name} (Імовірність: {attrP2.Probability * 100}%)");
      }
      else
      {
        Console.WriteLine($"{person2.Name} не має визначених почуттів до {person1.GetType().Name}.");
      }

      if (p1LikesP2 && p2LikesP1)
      {
        Console.WriteLine("Взаємна симпатія!");
        string childTypeName = attrP1.ChildType;
        string childName = person2.Name;

        Type typeOfChild = Type.GetType(childTypeName);
        if (typeOfChild == null)
        {
          Console.WriteLine($"Помилка: не вдалося знайти тип нащадка '{childTypeName}'.");
          return null;
        }

        IHasName child;
        try
        {
          if (typeOfChild == typeof(Book))
          {
            child = (IHasName)Activator.CreateInstance(typeOfChild, childName);
          }
          else if (typeof(Human).IsAssignableFrom(typeOfChild))
          {
            child = (IHasName)Activator.CreateInstance(typeOfChild);
          }
          else
          {
            child = (IHasName)Activator.CreateInstance(typeOfChild);
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine($"Помилка при створенні нащадка типу '{childTypeName}': {ex.Message}");
          return null;
        }

        PropertyInfo patronymicProp = child.GetType().GetProperty("Patronymic");
        if (patronymicProp != null && child is Human childHuman)
        {
          Human father = (person1.Gender == Gender.Male) ? person1 : person2;
          string suffix = childHuman.Gender == Gender.Male ? "ович" : "овна";
          patronymicProp.SetValue(child, father.Name + suffix);
        }

        Console.WriteLine($"Народжений нащадок: {child} (Тип: {child.GetType().Name})");
        return child;
      }
      else
      {
        Console.WriteLine("Симпатії не виникло або вона не взаємна. Пара не утворилася.");
        return null;
      }
    }
  }
}