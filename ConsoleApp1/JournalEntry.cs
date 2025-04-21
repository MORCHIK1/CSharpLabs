using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  internal class JournalEntry
  {
    public string CollectionName { get; set; }
    public string TypeOfChanges { get; set; }
    public StudentTheThird RelatedChanges { get; set; }

    public JournalEntry(string collectionName, string typeOfChanges, StudentTheThird relatedChanges)
    {
      CollectionName = collectionName;
      TypeOfChanges = typeOfChanges;
      RelatedChanges = relatedChanges;
    }

    public JournalEntry() : this(collectionName: "Name",
                                            typeOfChanges: "Change",
                                            relatedChanges: new StudentTheThird())
    { }

    public override string ToString()
    {
      return CollectionName + ' ' + TypeOfChanges + ' ' + RelatedChanges.ToString();
    }
  }
}
