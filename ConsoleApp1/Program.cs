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
      PersonTheThird A = new PersonTheThird("Tester", "Texter", new DateTime(2004, 6, 1, 7, 47, 0));
      PersonTheThird B = new PersonTheThird("Tester", "Texter", new DateTime(2004, 6, 1, 7, 47, 0));

      if (A.Equals(B)) Console.WriteLine($"{A.GetHashCode()}, {B.GetHashCode()}");

      Exam mathExam = new Exam("Math", 5, new DateTime());
      Test test = new Test("History", true);

      StudentTheThird GreatStudent = new StudentTheThird(A, Education.Master, 500, [test], [mathExam]);


      Exam programmingExam = new Exam("Programming", 2, new DateTime());
      Exam algebraExam = new Exam("Algebra", 4, new DateTime());
      Exam geometryExam = new Exam("Geometry", 5, new DateTime());
      List<Exam> ExamsList = [mathExam, programmingExam, algebraExam, geometryExam];

      GreatStudent.AddExams(ExamsList);

      Console.WriteLine(GreatStudent);

      Console.WriteLine(GreatStudent.StudentPerson);

      StudentTheThird CheapCopy = (StudentTheThird)GreatStudent.DeepCopy();

      List<Exam> ExamsForCopyTest = [programmingExam, programmingExam];

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
        StudentTheThird ErrorGroupStudent = new StudentTheThird(A, Education.Master, 700, [], []);
      }
      catch (Exception err)
      {
        Console.WriteLine($"{err.Message}");
      }

    }
  }
}
