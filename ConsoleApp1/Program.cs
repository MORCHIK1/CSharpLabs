using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
  delegate void StudentListHandler(object source, StudentListEventHandler args);
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
      StudentCollectionTheFifth collection1 = new StudentCollectionTheFifth("Group A");
      StudentCollectionTheFifth collection2 = new StudentCollectionTheFifth("Group B");

      // 2. Create two Journal objects
      Journal journal1 = new Journal();
      Journal journal2 = new Journal();

      // 3. Subscribe journal1 to events from collection1
      collection1.StudentCountChanged += journal1.StudentCountChangedHandler;
      collection1.StudentReferenceChanged += journal1.StudentReferenceChangedHandler;

      // 4. Subscribe journal2 to events from BOTH collection1 and collection2
      collection1.StudentCountChanged += journal2.StudentCountChangedHandler;
      collection1.StudentReferenceChanged += journal2.StudentReferenceChangedHandler;
      collection2.StudentCountChanged += journal2.StudentCountChangedHandler;
      collection2.StudentReferenceChanged += journal2.StudentReferenceChangedHandler;

      Console.WriteLine("--- Making changes to collections ---");

      // 5. Make changes to collection1
      Console.WriteLine("\n>>> Adding defaults to Collection 1...");
      collection1.AddDefaults();

      Console.WriteLine("\n>>> Adding specific students to Collection 1...");
      collection1.AddStudents(
          new StudentTheThird(new PersonTheThird("Alice", "Smith", new DateOnly(2001, 1, 10)), Education.Bachelor, 101),
          new StudentTheThird(new PersonTheThird("Bob", "Jones", new DateOnly(2000, 11, 20)), Education.Master, 305)
      );

      Console.WriteLine("\n>>> Removing student at index 1 from Collection 1...");
      bool removed = collection1.Remove(1);
      Console.WriteLine($"Removal successful: {removed}");

      Console.WriteLine("\n>>> Removing non-existent student (index 10) from Collection 1...");
      removed = collection1.Remove(10);
      Console.WriteLine($"Removal successful: {removed}");


      Console.WriteLine("\n>>> Assigning new student via indexer [0] to Collection 1 (init)...");
      collection1[0] = new StudentTheThird(new PersonTheThird("Charlie", "Brown", new DateOnly(2003, 3, 3)), Education.SecondEducation, 402);

      Console.WriteLine("\n>>> Assigning another new student via indexer [1] to Collection 1 (init)...");
      try
      {
        collection1[1] = new StudentTheThird(new PersonTheThird("Diana", "Prince", new DateOnly(1999, 9, 9)), Education.Bachelor, 102);
      }
      catch (IndexOutOfRangeException e)
      {
        Console.WriteLine($"Caught expected exception: {e.Message}");
        collection1.AddStudents(new StudentTheThird(new PersonTheThird("Temporary", "Student", DateOnly.MinValue), Education.SecondEducation, 500));
        Console.WriteLine("\n>>> Assigning again via indexer [1] after adding student...");
        collection1[1] = new StudentTheThird(new PersonTheThird("Diana", "Prince", new DateOnly(1999, 9, 9)), Education.Bachelor, 102);
      }


      // 6. Make changes to collection2
      Console.WriteLine("\n>>> Adding defaults to Collection 2...");
      collection2.AddDefaults();

      Console.WriteLine("\n>>> Removing student at index 0 from Collection 2...");
      removed = collection2.Remove(0);
      Console.WriteLine($"Removal successful: {removed}");


      Console.WriteLine("\n--- Displaying Journals ---");

      // 7. Print the contents of both journals
      Console.WriteLine("\n--- Journal 1 (Subscribed to Collection 1 only) ---");
      Console.WriteLine(journal1.ToString());

      Console.WriteLine("\n--- Journal 2 (Subscribed to Collection 1 AND Collection 2) ---");
      Console.WriteLine(journal2.ToString());


      Console.WriteLine("\n--- Displaying Final Collections ---");
      Console.WriteLine(collection1.ToString());
      Console.WriteLine(collection2.ToString());
    }
  }
}
