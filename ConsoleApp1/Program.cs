using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace GenealogySimulator
{
  public interface IHasName
  {
    string Name { get; }
  }

  public enum Gender
  {
    Male,
    Female
  }

  class Program
  {
    private static readonly Random Rand = new Random();
    private static readonly List<Type> MaleTypes = new List<Type> { typeof(Student), typeof(Botan) };
    private static readonly List<Type> FemaleTypes = new List<Type> { typeof(Girl), typeof(PrettyGirl), typeof(SmartGirl) };

    static Human CreateRandomHuman(List<Type> types)
    {
      Type type = types[Rand.Next(types.Count)];
      return (Human)Activator.CreateInstance(type);
    }

    static void Main(string[] args)
    {
      Console.OutputEncoding = System.Text.Encoding.UTF8;

      if (DateTime.Now.DayOfWeek == DayOfWeek.Sunday)
      {
        Console.WriteLine("Сьогодні неділя, консоль не працює. Приходьте завтра!");
        Console.ReadKey();
        return;
      }

      Console.WriteLine("Симулятор знайомств запущено!");
      Console.WriteLine("Натисніть Enter для створення нової пари, Q або F10 для виходу.");
      Console.WriteLine("----------------------------------------------------");

      while (true)
      {
        Human person1 = CreateRandomHuman(MaleTypes);
        Human person2 = CreateRandomHuman(FemaleTypes);

        try
        {
          IHasName child = MeetingSimulator.Couple(person1, person2);
        }
        catch (SameGenderException ex)
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine($"Помилка: {ex.Message}");
          Console.ResetColor();
        }
        catch (Exception ex)
        {
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          Console.WriteLine($"Сталася неочікувана помилка: {ex.Message}");
          Console.ResetColor();
        }

        Console.WriteLine("----------------------------------------------------");
        Console.Write("Натисніть Enter для наступної пари, Q або F10 для виходу: ");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        Console.WriteLine();

        if (keyInfo.Key == ConsoleKey.Q || keyInfo.Key == ConsoleKey.F10)
        {
          break;
        }
      }
      Console.WriteLine("Симулятор завершує роботу.");
    }
  }
}