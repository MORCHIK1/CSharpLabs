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
      StudentCollection studentCollection = new StudentCollection();
      StudentTheThird andrii = TestCollection.Create(5);
      StudentTheThird vasyl = TestCollection.Create(10);

      studentCollection.AddStudents([new StudentTheThird(), andrii, vasyl]);


      Console.WriteLine(studentCollection.ToString());

      studentCollection.SortByAverage();

      Console.WriteLine(studentCollection.ToString());

      studentCollection.SortByBirthdayDate();

      Console.WriteLine(studentCollection.ToString());

      studentCollection.SortBySurname();

      Console.WriteLine(studentCollection.MaxAverage);

      foreach (var item in studentCollection.MastersStudents)
      {
        Console.WriteLine(item);
      }

      foreach (var item in studentCollection.AverageMarkGroup(62.5))
      {
        Console.WriteLine(item);
      }

      int studentsInCollection = 100000; //------------------------ Number of students

      System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();

      StudentTheThird firstStud = TestCollection.Create(1);
      StudentTheThird halfStud = TestCollection.Create(studentsInCollection / 2);
      StudentTheThird lastStud = TestCollection.Create(studentsInCollection - 1);
      StudentTheThird theForgottenStud = new StudentTheThird();

      TestCollection testCollection = new TestCollection(studentsInCollection);

      // ------------------------------------------------------------------------ List Person Search

      watch.Start();
      testCollection.FindListPerson(firstStud);
      watch.Stop();
      Console.WriteLine("Список Person перший елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindListPerson(halfStud);
      watch.Stop();
      Console.WriteLine("Список Person центральний елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindListPerson(lastStud);
      watch.Stop();
      Console.WriteLine("Список Person останнiй елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindListPerson(theForgottenStud);
      watch.Stop();
      Console.WriteLine("Список Person неiснуючий елемент - " + watch.Elapsed + "\n");

      // ------------------------- Dict Person Search

      watch.Restart();
      testCollection.FindDictPerson(firstStud.StudentPerson);
      watch.Stop();
      Console.WriteLine("Словник Person перший елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindDictPerson(halfStud.StudentPerson);
      watch.Stop();
      Console.WriteLine("Словник Person центральний елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindDictPerson(lastStud.StudentPerson);
      watch.Stop();
      Console.WriteLine("Словник Person останнiй елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindDictPerson(theForgottenStud.StudentPerson);
      watch.Stop();
      Console.WriteLine("Словник Person неiснуючий елемент - " + watch.Elapsed + "\n");

      // ------------------------- List string Search
      string firstStudstr = "0";
      string halfStudstr = $"{studentsInCollection / 2}";
      string lastStudstr = $"{studentsInCollection - 1}";
      string theForgottenStudstr = "Nothing";

      watch.Restart();
      testCollection.FindListString("Value String " + firstStudstr);
      watch.Stop();
      Console.WriteLine("Список String перший елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindListString("Value String " + halfStudstr);
      watch.Stop();
      Console.WriteLine("Список String центральний елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindListString("Value String " + lastStudstr);
      watch.Stop();
      Console.WriteLine("Список String останнiй елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindListString("Value String " + theForgottenStudstr);
      watch.Stop();
      Console.WriteLine("Список String неiснуючий елемент - " + watch.Elapsed + "\n");

      // ------------------------- Dict String Search

      watch.Restart();
      testCollection.FindDictString(TestCollection.Create(0));
      watch.Stop();
      Console.WriteLine("Словник String перший елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindDictString(TestCollection.Create(studentsInCollection / 2));
      watch.Stop();
      Console.WriteLine("Словник String центральний елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindDictString(TestCollection.Create(studentsInCollection - 1));
      watch.Stop();
      Console.WriteLine("Словник String останнiй елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindDictString(new StudentTheThird());
      watch.Stop();
      Console.WriteLine("Словник String неiснуючий елемент - " + watch.Elapsed + "\n");


      // --------------------------------------------------------------------- List Immutable Person Search

      watch.Start();
      testCollection.FindImmutListPerson(firstStud);
      watch.Stop();
      Console.WriteLine("Список Immutable Person перший елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindImmutListPerson(halfStud);
      watch.Stop();
      Console.WriteLine("Список Immutable Person центральний елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindImmutListPerson(lastStud);
      watch.Stop();
      Console.WriteLine("Список Immutable Person останнiй елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindImmutListPerson(theForgottenStud);
      watch.Stop();
      Console.WriteLine("Список Immutable Person неiснуючий елемент - " + watch.Elapsed + "\n");

      // ------------------------- Dict Immutable Person Search

      watch.Restart();
      testCollection.FindImmutDictPerson(firstStud.StudentPerson);
      watch.Stop();
      Console.WriteLine("Словник Immutable Person перший елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindImmutDictPerson(halfStud.StudentPerson);
      watch.Stop();
      Console.WriteLine("Словник Immutable Person центральний елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindImmutDictPerson(lastStud.StudentPerson);
      watch.Stop();
      Console.WriteLine("Словник Immutable Person останнiй елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindImmutDictPerson(theForgottenStud.StudentPerson);
      watch.Stop();
      Console.WriteLine("Словник Immutable Person неiснуючий елемент - " + watch.Elapsed + "\n");

      // ------------------------- List Immutable string Search

      watch.Restart();
      testCollection.FindImmutListString("Value String " + firstStudstr);
      watch.Stop();
      Console.WriteLine("Список Immutable String перший елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindImmutListString("Value String " + halfStudstr);
      watch.Stop();
      Console.WriteLine("Список Immutable String центральний елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindImmutListString("Value String " + lastStudstr);
      watch.Stop();
      Console.WriteLine("Список Immutable String останнiй елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindImmutListString("Value String " + theForgottenStudstr);
      watch.Stop();
      Console.WriteLine("Список Immutable String неiснуючий елемент - " + watch.Elapsed + "\n");

      // ------------------------- Dict Immutable String Search

      watch.Restart();
      testCollection.FindImmutDictString(TestCollection.Create(0));
      watch.Stop();
      Console.WriteLine("Словник Immutable String перший елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindImmutDictString(TestCollection.Create(studentsInCollection / 2));
      watch.Stop();
      Console.WriteLine("Словник Immutable String центральний елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindImmutDictString(TestCollection.Create(studentsInCollection - 1));
      watch.Stop();
      Console.WriteLine("Словник Immutable String останнiй елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindImmutDictString(new StudentTheThird());
      watch.Stop();
      Console.WriteLine("Словник Immutable String неiснуючий елемент - " + watch.Elapsed + "\n");

      // ------------------------------------------------------------- List Sorted Person Search

      watch.Start();
      testCollection.FindSortListPerson(firstStud);
      watch.Stop();
      Console.WriteLine("Список Sorted Person перший елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindSortListPerson(halfStud);
      watch.Stop();
      Console.WriteLine("Список Sorted Person центральний елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindSortListPerson(lastStud);
      watch.Stop();
      Console.WriteLine("Список Sorted Person останнiй елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindSortListPerson(theForgottenStud);
      watch.Stop();
      Console.WriteLine("Список Sorted Person неiснуючий елемент - " + watch.Elapsed + "\n");

      // ------------------------- Dict Sorted Person Search

      watch.Restart();
      testCollection.FindSortDictPerson(firstStud.StudentPerson);
      watch.Stop();
      Console.WriteLine("Словник Sorted Person перший елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindSortDictPerson(halfStud.StudentPerson);
      watch.Stop();
      Console.WriteLine("Словник Sorted Person центральний елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindSortDictPerson(lastStud.StudentPerson);
      watch.Stop();
      Console.WriteLine("Словник Sorted Person останнiй елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindSortDictPerson(theForgottenStud.StudentPerson);
      watch.Stop();
      Console.WriteLine("Словник Sorted Person неiснуючий елемент - " + watch.Elapsed + "\n");

      // ------------------------- List Sorted string Search

      watch.Restart();
      testCollection.FindSortListString("Value String " + firstStudstr);
      watch.Stop();
      Console.WriteLine("Список Sorted String перший елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindSortListString("Value String " + halfStudstr);
      watch.Stop();
      Console.WriteLine("Список Sorted String центральний елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindSortListString("Value String " + lastStudstr);
      watch.Stop();
      Console.WriteLine("Список Sorted String останнiй елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindSortListString("Value String " + theForgottenStudstr);
      watch.Stop();
      Console.WriteLine("Список Sorted String неiснуючий елемент - " + watch.Elapsed + "\n");

      // ------------------------- Dict Sorted String Search

      watch.Restart();
      testCollection.FindSortDictString(TestCollection.Create(0));
      watch.Stop();
      Console.WriteLine("Словник Sorted String перший елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindSortDictString(TestCollection.Create(studentsInCollection / 2));
      watch.Stop();
      Console.WriteLine("Словник Sorted String центральний елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindSortDictString(TestCollection.Create(studentsInCollection - 1));
      watch.Stop();
      Console.WriteLine("Словник Sorted String останнiй елемент - " + watch.Elapsed);

      watch.Restart();
      testCollection.FindSortDictString(new StudentTheThird());
      watch.Stop();
      Console.WriteLine("Словник Sorted String неiснуючий елемент - " + watch.Elapsed + "\n");
    }
  }
}