using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class Person
  {
    private string _name = default!;
    private string _surname = default!;
    private System.DateTime _birthday = default!;

    public Person(string name, string surname, System.DateTime birthday)
    {
      Name = name;
      Surname = surname;
      Birthday = birthday;
    }

    public Person() : this(name: "Default Name", surname: "Default Surname", birthday: new DateTime())
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
  }
}
