using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class NewStudent : Person, IDateAndCopy, IEnumerable
  {
    public Person StudentPerson { get; init; } = new Person();
    private Education _formOfEducation;
    private int _groupNumber;
    private System.Collections.ArrayList _testList;
    private System.Collections.ArrayList _examList;

    public NewStudent(Person studentPerson,
               Education formOfEducation,
               int groupNumber,
               System.Collections.ArrayList testList,
               System.Collections.ArrayList examList)
    {
      StudentPerson = studentPerson;
      FormOfEducation = formOfEducation;
      GroupNumber = groupNumber;
      TestList = testList;
      ExamList = examList;
    }
    public NewStudent(Person studentPerson,
                    Education formOfEducation,
                    int groupNumber)
    {
      StudentPerson = studentPerson;
      FormOfEducation = formOfEducation;
      GroupNumber = groupNumber;
    }

    public NewStudent() : this(studentPerson: new Person(),
                            formOfEducation: new(),
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
      init { 
        if(value <= 100 || value > 699)
        {
          throw new ArgumentOutOfRangeException(nameof(GroupNumber), "Invalid group number! Group number should be in (100; 699) range");
        }  
        _groupNumber = value; 
      }
    }
    public System.Collections.ArrayList TestList
    {
      get { return _testList; }
      init { _testList = value; }
    }
    public System.Collections.ArrayList ExamList
    {
      get { return _examList; }
      set { _examList = value; }
    }

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

    public void AddExams(System.Collections.ArrayList newExamList)
    {
      if(ExamList is null)
      {
        ExamList = newExamList;
        return;
      }

      for(int i=0; i<newExamList.Count; ++i)
      {
        ExamList.Add(newExamList[i]);
      }
    }

    public override string ToString()
    {
      StringBuilder res = new StringBuilder(FormOfEducation.ToString() + ' ' + GroupNumber.ToString() + ' ');
      for (int i = 0; i < ExamList.Count; ++i)
      {
        res.Append(ExamList[i].ToString());
      }

      res.Append(' ');

      for (int i = 0; i < TestList.Count; ++i)
      {
        res.Append(TestList[i].ToString());
      }
      return res.ToString();
    }

    public string ToShortString()
    {
      return FormOfEducation.ToString() + ' ' + GroupNumber.ToString() + ' ' + Average.ToString() + ' ';
    }

    public virtual object DeepCopy()
    {
      System.Collections.ArrayList CopiedExamList = [];
      System.Collections.ArrayList CopiedTestList = [];
      Person CopiedStudentPerson = (Person)StudentPerson.DeepCopy();

      for (int i = 0; i < ExamList.Count; ++i)
      {
        CopiedExamList.Add(((Exam)ExamList[i]).DeepCopy());
      }

      for (int i = 0; i < TestList.Count; ++i)
      {
        CopiedTestList.Add(((Test)TestList[i]).DeepCopy());
      }

      NewStudent copied = new NewStudent(CopiedStudentPerson,
                                       FormOfEducation,
                                       GroupNumber,
                                       testList: CopiedTestList,
                                       examList: CopiedExamList);
      return copied;
    }
    public IEnumerator GetEnumerator()
    {
      throw new NotImplementedException();
    }
  }
}
