using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConsoleApp1
{
  class PersonTheThird : IDateAndCopy, IComparable, IComparer<PersonTheThird>
  {
    private string _name = default!;
    private string _surname = default!;
    private System.DateOnly _birthday = default!;
    public DateOnly Date { get => _birthday; init => _birthday = value; }
    public PersonTheThird(string name,
                  string surname,
                  System.DateOnly birthday)
    {
      Name = name;
      Surname = surname;
      Birthday = birthday;
    }

    public PersonTheThird() : this(name: "Default Name",
                           surname: "Default Surname",
                           birthday: new DateOnly())
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
    public System.DateOnly Birthday
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
      _birthday = new DateOnly(Year, _birthday.Month, _birthday.Day);
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
      return obj is PersonTheThird person &&
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
      PersonTheThird copied = new PersonTheThird(Name, Surname, Birthday);
      return copied;
    }

    public int CompareTo(object? obj)
    {
      if(this is not null || obj is not null)
      {
        if (obj is PersonTheThird)
        {
          return Surname.CompareTo((obj as PersonTheThird).Surname);
        }
        throw new ArgumentException("Object is not a Person");
      }
      throw new ArgumentNullException("One of the objects is null");
    }
    int IComparer<PersonTheThird>.Compare(PersonTheThird? x, PersonTheThird? y)
    {
      if(x is null || y is null) throw new NullReferenceException("One of the Persons is null");

      return x.Date.CompareTo(y.Date);
    }

    public static bool operator ==(PersonTheThird a, PersonTheThird b) => a.Equals(b);
    public static bool operator !=(PersonTheThird a, PersonTheThird b) => !(a.Equals(b));
  }
}
