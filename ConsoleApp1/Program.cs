using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
  interface IDateAndCopy
  {
    object DeepCopy();
    System.DateOnly Date { get; init; }
  }
  enum Education
  {
    Master,
    Bachelor,
    SecondEducation
  };
  class Program
  {
    public static void Main()
    {
      StudentCollectionTheFifth studentCollection1 = new StudentCollectionTheFifth();
      StudentCollectionTheFifth studentCollection2 = new StudentCollectionTheFifth();

      Journal journal1 = new Journal();
      Journal journal2 = new Journal();

      Console.WriteLine(journal1);
      Console.WriteLine(journal2);
    }
  }
}