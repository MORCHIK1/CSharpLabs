using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class NewStudent : IDateAndCopy
    {
    private Education _formOfEducation;
    private int _groupNumber;
    private System.Collections.ArrayList _testList ;
    private System.Collections.ArrayList _examList;

    public NewStudent(Education formOfEducation,
               int groupNumber,
               System.Collections.ArrayList testList,
               System.Collections.ArrayList examList)
    {
      FormOfEducation = formOfEducation;
      GroupNumber = groupNumber;
      TestList = testList;
      ExamList = examList;
    }

    public NewStudent() : this(formOfEducation: new(),
                            groupNumber: new(),
                            testList: [],
                            examList: [])
    { }

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
    public System.Collections.ArrayList TestList
    {
      get { return _testList; }
      init { _testList = value; }
    }
    public System.Collections.ArrayList ExamList
    {
      get { return _examList; }
      init { _examList = value; }
    }

    public Person StudentPerson { get; init; } = new Person();

    public double Average
    {
      get
      {
        double res = 0.0;
        foreach (Exam examGrade in ExamList)
        {
          res += examGrade.Grade;
        }
        res = ExamList.Count == 0 ? 0 : res / ExamList.Count;
        return res;
      }
    }

    public DateTime Date { get => new DateTime(); init => Date = value; }

    public void AddExams(System.Collections.ArrayList newExamList)
    {
      ExamList.Add(newExamList);
    }

    public override string ToString()
    {
      string res = FormOfEducation.ToString() + ' ' + GroupNumber.ToString() + ' ';
      for (int i = 0; i < ExamList.Count; ++i)
      {
        res += ExamList[i].ToString();
      }
      res += ' ';
      for (int i = 0; i < TestList.Count; ++i)
      {
        res += TestList[i].ToString();
      }
      return res;
    }

    public string ToShortString()
    {
      return FormOfEducation.ToString() + ' ' + GroupNumber.ToString() + ' ' + Average.ToString() + ' ';
    }

    public virtual object DeepCopy()
    {
      NewStudent copied = new NewStudent(FormOfEducation, GroupNumber, TestList, ExamList);
      return copied;
    }
  }
}
