using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class Test : IDateAndCopy
  {
    public string TestSubjectName { get; set; }
    public bool TestPassed { get; set; }
    public DateTime Date { get => new DateTime(); init => Date = value; }

    public Test(string testSubjectName,
                bool testPassed)
    {
      TestSubjectName = testSubjectName;
      TestPassed = testPassed;
    }

    public Test() : this(testSubjectName: "Subject",
                         testPassed: false)
    { }

    public override string ToString()
    {
      return TestSubjectName + ' ' + TestPassed.ToString() + ' ';
    }

    public virtual object DeepCopy()
    {
      Test copied = new Test(TestSubjectName, TestPassed);
      return copied;
    }
  }
}
