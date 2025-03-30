using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
  interface IDateAndCopy
  {
    object DeepCopy();
    System.DateTime Date { get; init; }
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
      StudentCollection studentCollection = new StudentCollection();
      StudentTheThird andrii = new StudentTheThird(new PersonTheThird("Andrii", "A", new DateTime(2012,12,30)), Education.Master, 159);
      StudentTheThird vasyl = new StudentTheThird(new PersonTheThird("Vasyl", "V", new DateTime(2008, 12, 30)), Education.Master, 159);


      studentCollection.AddStudents([new StudentTheThird(), andrii, vasyl]);


      Console.WriteLine(studentCollection.ToString());

      studentCollection.SortByAverage();

      Console.WriteLine(studentCollection.ToString());

      studentCollection.SortByBirthdayDate();

      Console.WriteLine(studentCollection.ToString());

      studentCollection.SortBySurname();
    }
  }
}
