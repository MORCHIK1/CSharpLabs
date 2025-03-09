using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class Test
  {
    public string TestSubjectName { get; set; }
    public bool TestPassed { get; set; }

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
  }
}
