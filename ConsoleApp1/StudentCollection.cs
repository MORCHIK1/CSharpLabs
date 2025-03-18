using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class StudentCollection
  {
    List<StudentTheThird> _studentTheThird;
      
    public void AddDefaults()
    {
      ListOfStudents.Add(new StudentTheThird());
      ListOfStudents.Add(new StudentTheThird());
    }

    public void AddStudents(params StudentTheThird[] NewStudents)
    {
      if (NewStudents is null) return;
      if(ListOfStudents is null)
      {
        ListOfStudents = [.. NewStudents];
        return;
      }
      ListOfStudents.AddRange(NewStudents);
    }

    public List<StudentTheThird> ListOfStudents
    {
      get { return _studentTheThird; }
      set { _studentTheThird = value; }
    }

    public virtual string ToString()
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
      ListOfStudents.Sort((s1, s2) => s1.StudentPerson.CompareTo(s2.StudentPerson));
    }
    public void SortByBirthdayDate()
    {
      PersonTheThird ComparerPerson = new PersonTheThird();
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
        return (List<StudentTheThird>)ListOfStudents.Where(Student => Student.FormOfEducation == Education.Master);
      }
    }
    public List<StudentTheThird> AverageMarkGroup(double value) //Have to return dict not list
    {
      return ListOfStudents.GroupBy(Student.Average == value).ToList(); 
    }
  }
}
