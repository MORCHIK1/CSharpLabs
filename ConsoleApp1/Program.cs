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
      Person A = new Person("Tester", "Texter", new DateTime(2004, 6, 1, 7, 47, 0));
      Person B = new Person("Tester", "Texter", new DateTime(2004, 6, 1, 7, 47, 0));

      if (A.Equals(B)) Console.WriteLine($"{A.GetHashCode()}, {B.GetHashCode()}");

      Exam mathExam = new Exam("Math", 5, new DateTime());
      Test test = new Test("History", true);

      NewStudent GreatStudent = new NewStudent(A, Education.Master, 500, [test], [mathExam]);


      Exam programmingExam = new Exam("Programming", 2, new DateTime());
      Exam algebraExam = new Exam("Algebra", 4, new DateTime());
      Exam geometryExam = new Exam("Geometry", 5, new DateTime());
      System.Collections.ArrayList ExamsList = [mathExam, programmingExam, algebraExam, geometryExam];

      GreatStudent.AddExams(ExamsList);

      Console.WriteLine(GreatStudent);

      Console.WriteLine(GreatStudent.StudentPerson);

      NewStudent CheapCopy = (NewStudent)GreatStudent.DeepCopy();

      System.Collections.ArrayList ExamsForCopyTest = [programmingExam, programmingExam];

      GreatStudent.AddExams(ExamsForCopyTest);

      Console.WriteLine(GreatStudent);

      Console.WriteLine(CheapCopy);


      foreach (var item in GreatStudent)
      {
        Console.WriteLine($"Foreach items: {item}");
      }

      foreach (Exam item in GreatStudent.GetExamsAboveScore(3))
      {
        Console.WriteLine(item);
      }

      try
      {
        NewStudent ErrorGroupStudent = new NewStudent(A, Education.Master, 700, [], []);
      }
      catch (Exception err)
      {
        Console.WriteLine($"{err.Message}");
      }

    }
  }
}
