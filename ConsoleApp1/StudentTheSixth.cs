using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Globalization;

namespace ConsoleApp1
{
  internal class StudentTheSixth : PersonTheThird, IDateAndCopy, IEnumerable
  {
    public PersonTheThird StudentPerson { get; set; } = new PersonTheThird();
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

    [JsonConstructor]
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
      set { _formOfEducation = value; }
    }
    public int GroupNumber
    {
      get { return _groupNumber; }
      set
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
      set { _testList = value; }
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

    private static readonly JsonSerializerOptions options = new()
    {
      WriteIndented = true
    };

    public override object DeepCopy()
    {
      string jsonString = JsonSerializer.Serialize(this, options);
      return JsonSerializer.Deserialize<StudentTheSixth>(jsonString, options) ?? new StudentTheSixth();
    }

    public bool Save(string filename)
    {
      try
      {
        string jsonString = JsonSerializer.Serialize(this, options);
        File.WriteAllText(filename, jsonString);
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error saving to file '{filename}': {ex.Message}");
        return false;
      }
    }

    public bool Load(string filename)
    {
      StudentTheSixth? loadedStudent;
      try
      {
        string jsonString = File.ReadAllText(filename);
        loadedStudent = JsonSerializer.Deserialize<StudentTheSixth>(jsonString, options);

        if (loadedStudent == null)
        {
          Console.WriteLine($"Error: Could not deserialize student data from '{filename}'.");
          return false;
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error loading from file '{filename}': {ex.Message}");
        return false;
      }

      Name = loadedStudent.Name;
      Surname = loadedStudent.Surname;
      Birthday = loadedStudent.Birthday;

      StudentPerson = (PersonTheThird)(loadedStudent.StudentPerson?.DeepCopy() ?? new PersonTheThird());
      FormOfEducation = loadedStudent.FormOfEducation;

      GroupNumber = loadedStudent.GroupNumber;

      TestList = loadedStudent.TestList?.Select(test => (Test)test.DeepCopy()).ToList() ?? new List<Test>();
      ExamList = loadedStudent.ExamList?.Select(exam => (Exam)exam.DeepCopy()).ToList() ?? new List<Exam>();

      return true;
    }

    public bool AddFromConsole()
    {
      Console.WriteLine("Enter exam data: SubjectName,Grade,ExamDate (e.g., Math,5,2023-10-27)");
      Console.WriteLine("Allowed delimiters: comma (,)");
      string? input = Console.ReadLine();

      if (string.IsNullOrWhiteSpace(input))
      {
        Console.WriteLine("Error: No input provided.");
        return false;
      }

      try
      {
        string[] parts = input.Split(',');
        if (parts.Length != 3)
        {
          Console.WriteLine("Error: Invalid input format. Expected 3 parts separated by comma.");
          return false;
        }

        string subject = parts[0].Trim();
        if (!int.TryParse(parts[1].Trim(), out int grade))
        {
          Console.WriteLine("Error: Invalid grade format. Grade must be an integer.");
          return false;
        }
        if (!DateOnly.TryParse(parts[2].Trim(), out DateOnly examDate))
        {
          Console.WriteLine("Error: Invalid date format. Date must be in yyyy-MM-dd format.");
          return false;
        }

        Exam newExam = new Exam(subject, grade, examDate);
        if (ExamList == null)
        {
          ExamList = new List<Exam>();
        }
        ExamList.Add(newExam);
        Console.WriteLine("Exam added successfully.");
        return true;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Error processing input: {ex.Message}");
        return false;
      }
    }


    public static bool Save(string filename, StudentTheSixth student)
    {
      if (student == null)
      {
        Console.WriteLine("Error: Cannot save a null object.");
        return false;
      }

      return student.Save(filename);
    }

    public static bool Load(string filename, StudentTheSixth student)
    {
      if (student == null)
      {
        Console.WriteLine("Error: Cannot load data into a null object reference.");
        return false;
      }

      StudentTheSixth? loadedStudent = new StudentTheSixth();

      return loadedStudent.Load(filename);
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