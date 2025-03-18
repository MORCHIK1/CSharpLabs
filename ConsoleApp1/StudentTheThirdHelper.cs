using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class StudentTheThirdHelper : IComparer<StudentTheThird>
  {
    public int Compare(StudentTheThird? x, StudentTheThird? y)
    {
      if (x is null || y is null) throw new NullReferenceException("One of the Persons is null");
      return x.Average.CompareTo(y.Average);
    }
  }
}
