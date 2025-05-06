using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class StudentCollectionTheFifth
  {
    private string CollectionName { get; set; }
    List<StudentTheThird> _listOfStudent;

    public StudentCollectionTheFifth(string collectionName)
    {
      CollectionName = collectionName;
      ListOfStudents = new List<StudentTheThird>();
    }

    public void AddDefaults()
    {
      ListOfStudents.Add(new StudentTheThird());
      ListOfStudents.Add(new StudentTheThird());
    }

    public void AddStudents(params StudentTheThird[] NewStudents)
    {
      if (NewStudents is null) return;
      if (ListOfStudents is null)
      {
        ListOfStudents = [.. NewStudents];
        return;
      }
      ListOfStudents.AddRange(NewStudents);
    }

    public List<StudentTheThird> ListOfStudents
    {
      get { return _listOfStudent; }
      set { _listOfStudent = value; }
    }

    public override sealed string ToString()
    {
      StringBuilder res = new StringBuilder();
      foreach (StudentTheThird item in ListOfStudents)
      {
        res.Append(item.ToString());
      }
      return res.ToString();
    }

    public string ToShortString()
    {
      StringBuilder res = new StringBuilder();
      foreach (StudentTheThird item in ListOfStudents)
      {
        res.Append(item.ToShortString());
      }
      return res.ToString();
    }

    public void SortBySurname()
    {
      ListOfStudents.Sort((s1, s2) => (s1.StudentPerson).CompareTo(s2.StudentPerson));
    }
    public void SortByBirthdayDate()
    {
      IComparer<PersonTheThird> ComparerPerson = new PersonTheThird();
      ListOfStudents.Sort(comparer: ComparerPerson);
    }
    public void SortByAverage()
    {
      StudentTheThirdHelper ComparerAverage = new StudentTheThirdHelper();
      ListOfStudents.Sort(ComparerAverage);
    }

    public double MaxAverage
    {
      get
      {
        if (ListOfStudents is null)
          throw new ArgumentNullException("ListOfStudents is null");

        if (ListOfStudents.Count == 0)
          return double.NaN;

        return ListOfStudents.MaxBy(x => x.Average)!.Average;
      }
    }
    public List<StudentTheThird> MastersStudents
    {
      get
      {
        if (ListOfStudents is null)
          return new List<StudentTheThird>();

        return ListOfStudents.Where(Student => Student.FormOfEducation == Education.Master).ToList();
      }
    }
    public List<StudentTheThird> AverageMarkGroup(double value)
    {
      return ListOfStudents.Where(student => student.Average == value).ToList();
    }

    public event StudentListHandler? StudentCountChanged;
    public event StudentListHandler? StudentReferenceChanged;

    private void OnStudentCountChanged(string typeOfChange, StudentTheThird student)
    {
      StudentCountChanged?.Invoke(this, new StudentListEventHandler(CollectionName, typeOfChange, student));
    }

    private void OnStudentReferenceChanged(StudentTheThird newStudent)
    {
      StudentReferenceChanged?.Invoke(this, new StudentListEventHandler(CollectionName, "Reference Change (Indexer Init)", newStudent));
    }

    public bool Remove(int j)
    {
      if (j >= 0 && j < ListOfStudents.Count)
      {
        StudentTheThird removedStudent = ListOfStudents[j];
        ListOfStudents.RemoveAt(j);
        OnStudentCountChanged("Remove", removedStudent);
        return true;
      }
      return false;
    }

    public StudentTheThird this[int index]
    {
      get
      {
        if (ListOfStudents == null)
        {
          throw new InvalidOperationException("The student list has not been initialized.");
        }
        if (index < 0 || index >= ListOfStudents.Count)
        {
          throw new IndexOutOfRangeException($"Index {index} is out of range for the student list");
        }
        return ListOfStudents[index];
      }
      set
      {
        if (_listOfStudent == null)
        {
          throw new InvalidOperationException("Cannot initialize via indexer: the student list is null.");
        }
        if (index < 0 || index >= _listOfStudent.Count)
        {
          throw new IndexOutOfRangeException($"Cannot initialize at index {index}: index is out of range (0 to {_listOfStudent.Count - 1}).");
        }
        _listOfStudent[index] = value;
        OnStudentReferenceChanged(value);
      }
    }
  }
}
