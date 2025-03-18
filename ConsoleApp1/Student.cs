/*
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
      set { _listOfExams = value; }
    }
    public double Average
    {
      get
      {
        double res = 0.0;
        foreach (Exam examGrade in ListOfExams)
        {
          res += examGrade.Grade;
        }
        res = ListOfExams.Length == 0 ? 0 : res / ListOfExams.Length;
        return res;
      }
    }
    public DateTime Date { get => new DateTime(); init => Date = value; }

    public bool this[Education sameFormOfEducation] => sameFormOfEducation == FormOfEducation;

    public void AddExams(Exam[] newExam)
    {
      if (newExam is null || newExam.Length == 0)
      {
        return;
      }

      if (ListOfExams is null || ListOfExams.Length == 0)
      {
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

    public virtual object DeepCopy()
    {
      Exam[] CopiedList = [];

      for (int i=0; i<ListOfExams.Length; ++i)
      {
        CopiedList[i] = (Exam)ListOfExams[i].DeepCopy();
      }

      Student copied = new Student(StudentInformation,FormOfEducation, GroupNumber, CopiedList);
      return copied;
    }
  }



}
*/