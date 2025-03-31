using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class TestCollection
  {
    System.Collections.Generic.List<PersonTheThird> _listOfPerson;
    System.Collections.Generic.List<string> _listOfString;
    System.Collections.Generic.Dictionary<PersonTheThird, StudentTheThird> _dictKeyPersonValStudent;
    System.Collections.Generic.Dictionary<string, StudentTheThird> _dictKeyStringValStudent;

    public static StudentTheThird Create(int index)
    {
      // Створюємо унікальну PersonTheThird для властивості StudentPerson
      var personInfo = new PersonTheThird(
          name: $"FName {index}",
          surname: $"LName {index}",
          // Генеруємо дату народження, наприклад, 20 років тому +/- index днів
          birthday: DateOnly.MinValue.AddYears(20).AddDays(index)
      );

      // Генеруємо номер групи в допустимому діапазоні [101, 699]
      int groupNumber = 101 + (index % 599); // 101 + (0..598) = 101..699

      // Вибираємо форму навчання циклічно
      Education eduForm = (Education)(index % Enum.GetValues(typeof(Education)).Length);

      // Створюємо порожні списки для тестів та екзаменів (можна додати генерацію)
      var tests = new List<Test>();
      var exams = new List<Exam>();


      exams.Add(new Exam { SubjectName = "Math", Grade = 60 + (index % 41), Date = DateOnly.MinValue.AddDays(10 + index % 5) });
      exams.Add(new Exam { SubjectName = "Physics", Grade = 55 + (index % 46), Date = DateOnly.MinValue.AddDays(5 + index % 3) });
     
      tests.Add(new Test { TestSubjectName = "History", TestPassed = (index % 2 == 0) });



      // Створюємо та повертаємо об'єкт StudentTheThird
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

      _listOfPerson = new List<PersonTheThird>(numOfElements);
      _listOfString = new List<string>(numOfElements);
      _dictKeyPersonValStudent = new Dictionary<PersonTheThird, StudentTheThird>(numOfElements);
      _dictKeyStringValStudent = new Dictionary<string, StudentTheThird>(numOfElements);

      for (int i = 0; i < numOfElements; ++i)
      {
        StudentTheThird student = Create(i);

        _listOfPerson.Add(student.StudentPerson);
        _listOfString.Add($"Value String {i}");
        _dictKeyPersonValStudent.Add(student.StudentPerson, student);
        _dictKeyStringValStudent.Add($"KeyString_{i}", student);
      }
    }
    public void FindListPerson(PersonTheThird findPerson)
    {
      Console.WriteLine(_listOfPerson.Contains(findPerson) ? 1 : -1);
      return;
    }
    public void FindListString(string findString)
    {
      Console.WriteLine(_listOfString.Contains(findString) ? 1 : -1);
      return;
    }
    public void FindDictPerson(PersonTheThird findKeyPerson)
    {
      Console.WriteLine(_dictKeyPersonValStudent.ContainsKey(findKeyPerson) ? 1 : -1);
      return;
    }
    public void FindDictString(StudentTheThird findValStudent)
    {
      Console.WriteLine(_dictKeyStringValStudent.ContainsValue(findValStudent) ? 1 : -1);
      return;
    }
  }
}
