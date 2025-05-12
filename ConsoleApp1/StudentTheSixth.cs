using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace ConsoleApp1
{
  internal class StudentTheSixth : PersonTheThird, IDateAndCopy, IEnumerable
  {
    public PersonTheThird StudentPerson { get; init; } = new PersonTheThird();
    private Education _formOfEducation;
    private int _groupNumber;
    private List<Test> _testList;
    private List<Exam> _examList;

    public StudentTheSixth(PersonTheThird studentPerson,
               Education formOfEducation,
    int groupNumber,
               List<Test> testList,
               List<Exam> examList)
    {
      Name = studentPerson.Name;
      Surname = studentPerson.Surname;
      Date = studentPerson.Date;
      StudentPerson = studentPerson;
      FormOfEducation = formOfEducation;
      GroupNumber = groupNumber;
      TestList = testList;
      ExamList = examList;
    }
    public StudentTheSixth(PersonTheThird studentPerson,
                    Education formOfEducation,
                    int groupNumber)
    {
      StudentPerson = studentPerson;
      FormOfEducation = formOfEducation;
      GroupNumber = groupNumber;
      TestList = [];
      ExamList = [];
    }

    public StudentTheSixth() : this(studentPerson: new PersonTheThird(),
                            formOfEducation: Education.Master,
                            groupNumber: 101,
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
      init
      {
        if (value < 101 || value > 699)
        {
          throw new ArgumentOutOfRangeException(nameof(GroupNumber), "Invalid group number! Group number should be in (100; 699) range");
        }
        _groupNumber = value;
      }
    }

    public List<Test> TestList
    {
      get { return _testList; }
      init { _testList = value; }
    }
    public List<Exam> ExamList
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

    public void AddExams(List<Exam> newExamList)
    {
      if (ExamList is null)
      {
        ExamList = newExamList;
        return;
      }
      ExamList.AddRange(newExamList);
    }

    public override string ToString()
    {
      StringBuilder res = new StringBuilder(StudentPerson.ToString() + ' ' + FormOfEducation.ToString() + ' ' + GroupNumber.ToString() + ' ');
      for (int i = 0; i < ExamList.Count; i++)
      {
        Exam item = ExamList[i];
        res.Append(item.ToString());
      }

      res.Append(' ');

      foreach (Test item in TestList)
      {
        res.Append(item.ToString());
      }

      res.Append($"\nTHIS AVERAGE ---- {Average}\n");

      return res.ToString();
    }

    public override string ToShortString()
    {
      return StudentPerson.ToString() + ' ' + FormOfEducation.ToString() + ' ' + GroupNumber.ToString() + ' ' + Average.ToString() + ' ';
    }

    public override object DeepCopy()
    {
      List<Exam> copiedExamList = [];
      List<Test> copiedTestList = [];
      PersonTheThird copiedStudentPerson = (PersonTheThird)StudentPerson.DeepCopy();

      foreach (Exam item in ExamList)
      {
        copiedExamList.Add((Exam)item.DeepCopy());
      }

      foreach (Test item in TestList)
      {
        copiedTestList.Add((Test)item.DeepCopy());
      }

      StudentTheSixth copied = new StudentTheSixth(copiedStudentPerson,
                                       FormOfEducation,
                                       GroupNumber,
                                       testList: copiedTestList,
                                       examList: copiedExamList);
      return copied;
    }
    public IEnumerator GetEnumerator()
    {
      var ExamsAndTests = new List<object>(ExamList.Count +
                                          TestList.Count);
      ExamsAndTests.AddRange(ExamList);
      ExamsAndTests.AddRange(TestList);

      return new ExamAndTestEnum(ExamsAndTests);
    }

    public IEnumerable<Exam> GetExamsAboveScore(int minScore)
    {
      foreach (var item in ExamList)
      {
        if (item.Grade > minScore)
        {
          yield return item;
        }
      }
    }

  }
}
public class ExamAndTestEnum : IEnumerator
{
  public List<object> list;
  int position = -1;

  public ExamAndTestEnum(List<object> collection)
  {
    ArgumentNullException.ThrowIfNull(collection);
    list = collection;
  }

  public bool MoveNext()
  {
    position++;
    return (position < list.Count);
  }

  public void Reset()
  {
    position = -1;
  }

  object IEnumerator.Current
  {
    get
    {
      return Current;
    }
  }

  public object Current
  {
    get
    {
      try
      {
        return list[position];
      }
      catch (IndexOutOfRangeException)
      {
        throw new InvalidOperationException();
      }
    }
  }


}