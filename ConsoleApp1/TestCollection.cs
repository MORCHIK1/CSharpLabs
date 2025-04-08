using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class TestCollection
  {
    System.Collections.Generic.List<PersonTheThird> listOfPerson;
    System.Collections.Generic.List<string> listOfString;
    System.Collections.Generic.Dictionary<PersonTheThird, StudentTheThird> dictKeyPersonValStudent;
    System.Collections.Generic.Dictionary<string, StudentTheThird> dictKeyStringValStudent;

    private ImmutableList<PersonTheThird> immutListPerson;
    private ImmutableList<string> immutListString;
    private ImmutableDictionary<PersonTheThird, StudentTheThird> immutDictPerson;
    private ImmutableDictionary<string, StudentTheThird> immutDictString;

    private SortedList<PersonTheThird, PersonTheThird> sortListPerson;
    private SortedList<string, string> sortListString;
    private SortedDictionary<PersonTheThird, StudentTheThird> sortDictPerson;
    private SortedDictionary<string, StudentTheThird> sortDictString;

    public static StudentTheThird Create(int index)
    {
      var personInfo = new PersonTheThird(
          name: $"FName {index}",
          surname: $"LName {index}",
          birthday: DateOnly.MinValue.AddYears(20).AddDays(index)
      );

      int groupNumber = 101 + (index % 599); // 101 + (0..598) = 101..699

      Education eduForm = (Education)(index % Enum.GetValues(typeof(Education)).Length);

      var tests = new List<Test>();
      var exams = new List<Exam>();


      exams.Add(new Exam { SubjectName = "Math", Grade = 60 + (index % 41), Date = DateOnly.MinValue.AddDays(10 + index % 5) });
      exams.Add(new Exam { SubjectName = "Physics", Grade = 55 + (index % 46), Date = DateOnly.MinValue.AddDays(5 + index % 3) });
     
      tests.Add(new Test { TestSubjectName = "History", TestPassed = (index % 2 == 0) });

      return new StudentTheThird(
          studentPerson: personInfo,
          formOfEducation: eduForm,
          groupNumber: groupNumber,
          testList: tests,
          examList: exams
      );
    }

    public TestCollection(int numOfElements)
    {
      if (numOfElements < 0) throw new ArgumentOutOfRangeException(nameof(numOfElements));

      listOfPerson = new List<PersonTheThird>(numOfElements);
      listOfString = new List<string>(numOfElements);
      dictKeyPersonValStudent = new Dictionary<PersonTheThird, StudentTheThird>(numOfElements);
      dictKeyStringValStudent = new Dictionary<string, StudentTheThird>(numOfElements);

      for (int i = 0; i < numOfElements; ++i)
      {
        StudentTheThird student = Create(i);

        listOfPerson.Add(student.StudentPerson);
        listOfString.Add($"Value String {i}");
        dictKeyPersonValStudent.Add(student.StudentPerson, student);
        dictKeyStringValStudent.Add($"KeyString_{i}", student);
      }
    }
    public void FindListPerson(PersonTheThird findPerson)
    {
      Console.WriteLine(listOfPerson.Contains(findPerson) ? 1 : -1);
      return;
    }
    public void FindListString(string findString)
    {
      Console.WriteLine(listOfString.Contains(findString) ? 1 : -1);
      return;
    }
    public void FindDictPerson(PersonTheThird findKeyPerson)
    {
      Console.WriteLine(dictKeyPersonValStudent.ContainsKey(findKeyPerson) ? 1 : -1);
      return;
    }
    public void FindDictString(StudentTheThird findValStudent)
    {
      Console.WriteLine(dictKeyStringValStudent.ContainsValue(findValStudent) ? 1 : -1);
      return;
    }
  }
}
