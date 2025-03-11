using System;
using System.Collections.Generic;
using System.Linq;

enum Education
{
  Master,
  Bachelor,
  SecondEducation
};

class Person
{
  private string _name = default!;
  private string _surname = default!;
  private System.DateTime _birthday = default!;

  public Person(string name, string surname, System.DateTime birthday)
  {
    Name = name;
    Surname = surname;
    Birthday = birthday;
  }

  public Person() : this(name: "Default Name", surname: "Default Surname", birthday: new DateTime())
  { }


  public string Name
  {
    get { return _name; }
    init { _name = value; }
  }
  public string Surname
  {
    get { return _surname; }
    init { _surname = value; }
  }
  public System.DateTime Birthday
  {
    get { return _birthday; }
    init { _birthday = value; }
  }

  public int GetYearBirthday
  {
    get { return _birthday.Year; }
  }

  public void SetYearBirthday(int Year)
  {
    _birthday = new DateTime(Year, _birthday.Month, _birthday.Day);
  }

  public override string ToString()
  {
    return _name + ' ' + _surname + ' ' + _birthday.ToString();
  }

  public virtual string ToShortString()
  {
    return _name + ' ' + _surname;
  }
}

class Exam
{
  public string SubjectName { get; set; }
  public int Grade { get; set; }
  public DateTime ExamDate { get; set; }

  public Exam(string subjectName, int grade, DateTime examDate)
  {
    SubjectName = subjectName;
    Grade = grade;
    ExamDate = examDate;
  }

  public Exam() : this(subjectName: "Exam", grade: 0, examDate: new DateTime())
  { }

  public override string ToString()
  {
    return SubjectName + ' ' + Grade.ToString() + ' ' + ExamDate.ToString() + ' ';
  }
}

class Student
{
  private Person _studentInformation = default!;
  private Education _formOfEducation = default!;
  private int _groupNumber;
  private Exam[] _listOfExams;

  public Student(Person studentInformation, Education formOfEducation, int groupNumber, Exam[] listOfExams)
  {
    StudentInformation = studentInformation;
    FormOfEducation = formOfEducation;
    GroupNumber = groupNumber;
    ListOfExams = listOfExams;
  }

  public Student() : this(studentInformation: new(), formOfEducation: new(), groupNumber: 0, listOfExams: [])
  { }

  public Person StudentInformation
  {
    get { return _studentInformation; }
    init { _studentInformation = value; }
  }
  public Education FormOfEducation
  {
    get { return _formOfEducation; }
    init { _formOfEducation = value; }
  }
  public int GroupNumber
  {
    get { return _groupNumber; }
    init { _groupNumber = value; }
  }

  public Exam[] ListOfExams
  {
    get { return _listOfExams; }
    init { _listOfExams = value; }
  }

  public double Average => ListOfExams.Any() ? ListOfExams.Average(exam => exam.Grade) : 0.0;

  public bool this[Education sameFormOfEducation] => sameFormOfEducation == FormOfEducation;

  public void AddExams(Exam[] newExam)
  {
    if (newExam is null || newExam.Length == 0)
    {
      return;
    }

    if (ListOfExams is null || ListOfExams.Length == 0) { 
      ListOfExams = newExam;
      return;
    } 

    Array.Resize<Exam>(ref _listOfExams, ListOfExams.Length + newExam.Length);
    Array.Copy(newExam, 0, ListOfExams, ListOfExams.Length - newExam.Length, newExam.Length);
  }

  public override string ToString()
  {
    StringBuilder res = new StringBuilder(StudentInformation.ToString() + ' ' + FormOfEducation.ToString() + ' ' + GroupNumber.ToString() + ' ');
    for (int i = 0; i < ListOfExams.Length; ++i)
    {
      res.Append(ListOfExams[i].ToString());
    }

    return res.ToString();
  }

  public string ToShortString()
  {
    return StudentInformation.ToString() + ' ' + FormOfEducation.ToString() + ' ' + GroupNumber.ToString() + ' ' + Average.ToString() + ' ';
  }
}


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
