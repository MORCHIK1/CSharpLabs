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

    public Journal() {
      entries = new List<JournalEntry>();
    }

    public override string ToString()
    {
      StringBuilder res = new StringBuilder();

      foreach (JournalEntry entry in entries)
      {
        res.Append(entry.ToString());
      }
      return res.ToString();
    }

    public void StudentCountChangedHandler(object source, StudentListEventHandler args)
    {
      entries.Add(new JournalEntry(args.CollectionName, args.TypeOfChanges, args.RelatedChanges));
    }

    public void StudentReferenceChangedHandler(object source, StudentListEventHandler args)
    {
      entries.Add(new JournalEntry(args.CollectionName, args.TypeOfChanges, args.RelatedChanges));
    }
  }
}
