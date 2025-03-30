using System;
using System.Collections.Generic;
using System.Linq;
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
          name: $"FName{index}",
          surname: $"LName{index}",
          // Генеруємо дату народження, наприклад, 20 років тому +/- index днів
          birthday: DateTime.Now.AddYears(-20).AddDays(index)
      );

      // Генеруємо номер групи в допустимому діапазоні [101, 699]
      int groupNumber = 101 + (index % 599); // 101 + (0..598) = 101..699

      // Вибираємо форму навчання циклічно
      Education eduForm = (Education)(index % Enum.GetValues(typeof(Education)).Length);

      // Створюємо порожні списки для тестів та екзаменів (можна додати генерацію)
      var tests = new List<Test>();
      var exams = new List<Exam>();

      // Можна додати кілька прикладів іспитів/тестів
      if (index % 3 == 0) // Додавати іспити для кожного третього студента
      {
        exams.Add(new Exam { SubjectName = "Math", Grade = 60 + (index % 41), Date = DateTime.Now.AddDays(-10 + index % 5) });
        exams.Add(new Exam { SubjectName = "Physics", Grade = 55 + (index % 46), Date = DateTime.Now.AddDays(-5 + index % 3) });
      }
      if (index % 2 == 0) // Додавати тести для кожного другого студента
      {
        tests.Add(new Test { TestSubjectName = "History", TestPassed = (index % 2 == 0), Date = DateTime.Now.AddDays(-20 + index % 7) });
      }


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
        PersonTheThird keyPerson = new PersonTheThird(
            $"KeyName{i}",
            $"KeySurname{i}",
            DateTime.Now.AddYears(-40).AddDays(i)
        );

        _listOfPerson.Add(new PersonTheThird());
        _listOfString.Add($"Value String {i}");
        _dictKeyPersonValStudent.Add(keyPerson, student);
        _dictKeyStringValStudent.Add($"KeyString_{i}", student);
      }
    }
    public int FindListPerson(PersonTheThird findPerson)
    {
      int startTime = Environment.TickCount;
      if (_listOfPerson.Contains(findPerson))
      {
        return Environment.TickCount - startTime;
      }
      return 0;
    }
    public int FindListString(string findString)
    {
      int startTime = Environment.TickCount;
      if (_listOfString.Contains(findString))
      {
        return Environment.TickCount - startTime;
      }
      return 0;
    }
    public int FindDictPerson(StudentTheThird findStudent)
    {
      int startTime = Environment.TickCount;
      if (_dictKeyPersonValStudent.ContainsValue(findStudent))
      {
        return Environment.TickCount - startTime;
      }
      return 0;
    }
    public int FindDictString(StudentTheThird findStudent)
    {
      int startTime = Environment.TickCount;
      if (_dictKeyStringValStudent.ContainsValue(findStudent))
      {
        return Environment.TickCount - startTime;
      }
      return 0;
    }
  }
}
