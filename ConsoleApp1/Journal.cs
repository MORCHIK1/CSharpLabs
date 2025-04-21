using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  internal class Journal
  {
    private List<JournalEntry> entries;

    public override string ToString()
    {
      StringBuilder res = new StringBuilder();

      foreach (JournalEntry entry in entries)
      {
        res.Append(entry.ToString());
      }
      return res.ToString();
    }
  }
}
