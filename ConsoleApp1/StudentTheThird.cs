using ConsoleApp1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class StudentTheThird : PersonTheThird, IDateAndCopy, IEnumerable
  {
    public PersonTheThird StudentPerson { get; init; } = new PersonTheThird();
    private Education _formOfEducation;
    private int _groupNumber;
    private List<Test> _testList;
    private List<Exam> _examList;

    public StudentTheThird(PersonTheThird studentPerson,
               Education formOfEducation,
               int groupNumber,
               List<Test> testList,
               List<Exam> examList)
    {
      StudentPerson = studentPerson;
      FormOfEducation = formOfEducation;
      GroupNumber = groupNumber;
      TestList = testList;
      ExamList = examList;
    }
    public StudentTheThird(PersonTheThird studentPerson,
                    Education formOfEducation,
                    int groupNumber)
    {
      StudentPerson = studentPerson;
      FormOfEducation = formOfEducation;
      GroupNumber = groupNumber;
    }

    public StudentTheThird() : this(studentPerson: new PersonTheThird(),
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
      init
      {
        if (value <= 100 || value > 699)
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

      for (int i = 0; i < newExamList.Count; ++i)
      {
        ExamList.Add(newExamList[i]);
      }
    }

    public override string ToString()
    {
      StringBuilder res = new StringBuilder(StudentPerson.ToString() + ' ' + FormOfEducation.ToString() + ' ' + GroupNumber.ToString() + ' ');
      foreach (Exam item in ExamList)
      {
        res.Append(item.ToString());
      }

      res.Append(' ');

      foreach(Test item in TestList)
      {
        res.Append(item.ToString());
      }
      return res.ToString();
    }

    public override string ToShortString()
    {
      return StudentPerson.ToString() + ' ' + FormOfEducation.ToString() + ' ' + GroupNumber.ToString() + ' ' + Average.ToString() + ' ';
    }

    public override object DeepCopy()
    {
      List<Exam> CopiedExamList = [];
      List<Test> CopiedTestList = [];
      PersonTheThird CopiedStudentPerson = (PersonTheThird)StudentPerson.DeepCopy();

      foreach (Exam item in ExamList)
      {
        CopiedExamList.Add((Exam)item.DeepCopy());
      }

      foreach (Test item in TestList)
      {
        CopiedTestList.Add((Test)item.DeepCopy());
      }

      StudentTheThird copied = new StudentTheThird(CopiedStudentPerson,
                                       FormOfEducation,
                                       GroupNumber,
                                       testList: CopiedTestList,
                                       examList: CopiedExamList);
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
        if (item is Exam && ((Exam)item).Grade > minScore)
        {
          yield return ((Exam)item);
        }
      }
    }

  }
}
public class ExamAndTestEnum : IEnumerator
{
  public List<object> _students;
  int position = -1;

  public ExamAndTestEnum(List<object> students)
  {
    _students = students;
  }

  public bool MoveNext()
  {
    position++;
    return (position < _students.Count);
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
        return _students[position];
      }
      catch (IndexOutOfRangeException)
      {
        throw new InvalidOperationException();
      }
    }
  }
}