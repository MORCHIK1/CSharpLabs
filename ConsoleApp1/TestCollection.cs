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

    //static StudentTheThird Create

    public TestCollection(int numOfElements)
    {
      _listOfPerson = new List<PersonTheThird>();
      _listOfString = new List<string>();
      _dictKeyPersonValStudent = new Dictionary<PersonTheThird, StudentTheThird>();
      _dictKeyStringValStudent = new Dictionary<string, StudentTheThird>();

      for (int i=0; i<numOfElements; ++i)
      {
        _listOfPerson.Add(new PersonTheThird());
        _listOfString.Add("");
        _dictKeyPersonValStudent.Add(new PersonTheThird($"{i}", "", default), new StudentTheThird());
        _dictKeyStringValStudent.Add($"{i}", new StudentTheThird());
      }
    }
    public int FindListPerson(PersonTheThird findPerson)
    {
      int startTime = Environment.TickCount;
      if (_listOfPerson.Contains(findPerson))
      {
        return Environment.TickCount - startTime;
      }
      return -1;
    }
    public int FindListString(string findString)
    {
      int startTime = Environment.TickCount;
      if (_listOfString.Contains(findString))
      {
        return Environment.TickCount - startTime;
      }
      return -1;
    }
    public int FindDictPerson(StudentTheThird findStudent)
    {
      int startTime = Environment.TickCount;
      if (_dictKeyPersonValStudent.ContainsValue(findStudent))
      {
        return Environment.TickCount - startTime;
      }
      return -1;
    }
    public int FindDictString(StudentTheThird findStudent)
    {
      int startTime = Environment.TickCount;
      if (_dictKeyStringValStudent.ContainsValue(findStudent))
      {
        return Environment.TickCount - startTime;
      }
      return -1;
    }
  }
}
