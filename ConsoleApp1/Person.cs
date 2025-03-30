using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
  class Person : IDateAndCopy
  {
    private string _name = default!;
    private string _surname = default!;
    private System.DateTime _birthday = default!;
    public DateTime Date { get => _birthday; init => _birthday = value; }
    public Person(string name,
                  string surname,
                  System.DateTime birthday)
    {
      Name = name;
      Surname = surname;
      Birthday = birthday;
    }

    public Person() : this(name: "Default Name",
                           surname: "Default Surname",
                           birthday: new DateTime())
    { }


    public string Name
    {
      get { return _name; }
      init { _name = value; }
    }
    public string Surname
    {
      get { return _surname; }
      init { _surname = value; }
    }
    public System.DateTime Birthday
    {
      get { return _birthday; }
      init { _birthday = value; }
    }

    public int GetYearBirthday
    {
      get { return _birthday.Year; }
    }

    public void SetYearBirthday(int Year)
    {
      _birthday = new DateTime(Year, _birthday.Month, _birthday.Day);
    }

    public override string ToString()
    {
      return _name + ' ' + _surname + ' ' + _birthday.ToString();
    }

    public virtual string ToShortString()
    {
      return _name + ' ' + _surname;
    }

    public override bool Equals(object? obj)
    {
      return obj is Person person &&
             Name == person.Name &&
             Surname == person.Surname &&
             Birthday == person.Birthday;
    }

    public override int GetHashCode()
    {
      return HashCode.Combine(Name, Surname, Birthday);
    }
    public virtual object DeepCopy()
    {
      Person copied = new Person(Name, Surname, Birthday);
      return copied;
    }

    public static bool operator ==(Person a, Person b) => a.Equals(b);
    public static bool operator !=(Person a, Person b) => !a.Equals(b);
  }
}
