using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
  delegate void StudentListHandler(object source, StudentListEventHandler args);
interface IDateAndCopy
  {
    object DeepCopy();
    System.DateOnly Date { get; init; }
  }
  enum Education
  {
    Master,
    Bachelor,
    SecondEducation
  };
  class Program
  {
    public static void Main()
    {
      
    }
  }
}