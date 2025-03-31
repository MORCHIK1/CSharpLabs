using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
  class Exam : IDateAndCopy
  {
    public string SubjectName { get; set; }
    public int Grade { get; set; }
    public DateOnly ExamDate { get; set; }
    public DateOnly Date { get => ExamDate; init => ExamDate = value; }

    public Exam(string subjectName,
                int grade,
                DateOnly examDate)
    {
      SubjectName = subjectName;
      Grade = grade;
      ExamDate = examDate;
    }

    public Exam() : this(subjectName: "Exam",
                         grade: 0,
                         examDate: new DateOnly())
    { }

    public override string ToString()
    {
      return SubjectName + ' ' + Grade.ToString() + ' ' + ExamDate.ToString() + ' ';
    }

    public virtual object DeepCopy()
    {
      Exam copied = new Exam(SubjectName, Grade, ExamDate);
      return copied;
    }
  }
}
