using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
  interface IDateAndCopy
  {
    object DeepCopy();
    System.DateTime Date { get; set; }
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
      Console.WriteLine("Input nRows and nColumns:");

      string[] input = Console.ReadLine().Split(' ');
      int nRows = Convert.ToInt32(input[0]);
      int nColumns = Convert.ToInt32(input[1]);
      int productOfColumnsAndRows = nRows * nColumns;

      Console.WriteLine("TickCount: {0}", Environment.TickCount);
      Student[] singleDimensionalArray = new Student[productOfColumnsAndRows];
      for (int i = 0; i < singleDimensionalArray.Length; ++i)
      {
        singleDimensionalArray[i] = new Student();
      }
      Console.WriteLine("TickCount: {0}", Environment.TickCount);


      Student[,] RectangularArray = new Student[nRows, nColumns];
      for (int i = 0; i < nRows; ++i)
      {
        for (int j = 0; j < nColumns; ++j)
        {
          RectangularArray[i, j] = new Student();
        }
      }
      Console.WriteLine("TickCount: {0}", Environment.TickCount);


      int nRowsForJagged = 0;
      while (productOfColumnsAndRows > 0)
      {
        nRowsForJagged++;
        productOfColumnsAndRows -= nRowsForJagged;
      }

      Student[][] JaggedArray = new Student[nRowsForJagged][];
      int currentColumnSize = 1;
      int elementsLeft = nRows * nColumns;

      for (int i = 0; i < nRowsForJagged; ++i)
      {
        currentColumnSize = i + 1;

        if (elementsLeft - i < 0) currentColumnSize = elementsLeft;
        elementsLeft -= currentColumnSize;

        JaggedArray[i] = new Student[currentColumnSize];

        for (int j = 0; j < currentColumnSize; ++j)
        {
          JaggedArray[i][j] = new Student();
        }
      }
      Console.WriteLine("TickCount: {0}", Environment.TickCount);


      Student FirstTaskStud = new Student();

      string firstTask = FirstTaskStud.ToShortString();
      Console.WriteLine($"{firstTask}");


      Exam mathExam = new Exam("Math", 5, new DateTime());
      Exam programmingExam = new Exam("Programming", 2, new DateTime());
      Exam algebraExam = new Exam("Algebra", 4, new DateTime());
      Exam geometryExam = new Exam("Geometry", 5, new DateTime());
      Exam[] ExamsList = { mathExam, programmingExam, algebraExam, geometryExam };

      Person Andrii = new Person("Andrii", "Andriivskiy", new DateTime(2004, 6, 1, 7, 47, 0));

      Student OneStudent = new Student(Andrii, Education.Master, 2, ExamsList);

      Console.WriteLine($"{OneStudent[Education.SecondEducation]}");
      Console.WriteLine($"{OneStudent[Education.Master]}");
      Console.WriteLine($"{OneStudent[Education.Bachelor]}");

      Exam[] addToExamList = { mathExam, algebraExam };

      Console.WriteLine(OneStudent);

      OneStudent.AddExams(addToExamList);

      Console.WriteLine(OneStudent.ToString());
    }
  }
}
