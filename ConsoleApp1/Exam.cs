using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  class Exam
  {
    public string SubjectName { get; set; }
    public int Grade { get; set; }
    public DateTime ExamDate { get; set; }

    public Exam(string subjectName, int grade, DateTime examDate)
    {
      SubjectName = subjectName;
      Grade = grade;
      ExamDate = examDate;
    }

    public Exam() : this(subjectName: "Exam", grade: 0, examDate: new DateTime())
    { }

    public override string ToString()
    {
      return SubjectName + ' ' + Grade.ToString() + ' ' + ExamDate.ToString() + ' ';
    }
  }
}
