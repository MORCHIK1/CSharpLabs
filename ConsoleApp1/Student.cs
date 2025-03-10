using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
  class Student : IDateAndCopy
  {
    private Person _studentInformation = default!;
    private Education _formOfEducation = default!;
    private int _groupNumber;
    private Exam[] _listOfExams;

    public Student(Person studentInformation,
                   Education formOfEducation,
                   int groupNumber,
                   Exam[] listOfExams)
    {
      StudentInformation = studentInformation;
      FormOfEducation = formOfEducation;
      GroupNumber = groupNumber;
      ListOfExams = listOfExams;
    }

    public Student() : this(studentInformation: new(),
                            formOfEducation: new(),
                            groupNumber: 0,
                            listOfExams: [])
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
    public DateTime Date { get => new DateTime(); init => Date = value; }

    public bool this[Education sameFormOfEducation] => sameFormOfEducation == FormOfEducation;

    public void AddExams(Exam[] newExam)
    {
      Array.Resize<Exam>(ref _listOfExams, ListOfExams.Length + newExam.Length);
      Array.Copy(newExam, 0, ListOfExams, ListOfExams.Length - newExam.Length, newExam.Length);
    }

    public override string ToString()
    {
      string res = StudentInformation.ToString() + ' ' + FormOfEducation.ToString() + ' ' + GroupNumber.ToString() + ' ';
      for (int i = 0; i < ListOfExams.Length; ++i)
      {
        res += ListOfExams[i].ToString();
      }
      return res;
    }

    public string ToShortString()
    {
      return StudentInformation.ToString() + ' ' + FormOfEducation.ToString() + ' ' + GroupNumber.ToString() + ' ' + Average.ToString() + ' ';
    }

    public virtual object DeepCopy()
    {
      Student copied = new Student(StudentInformation,FormOfEducation, GroupNumber, ListOfExams);
      return copied;
    }
  }



}
