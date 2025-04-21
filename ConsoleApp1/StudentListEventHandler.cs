using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  internal class StudentListEventHandler : System.EventArgs
  {
    public string CollectionName { get; set; }
    public string TypeOfChanges{ get; set; }
    public StudentTheThird RelatedChanges { get; set; }

    public StudentListEventHandler(string collectionName, string typeOfChanges, StudentTheThird relatedChanges)
    {
      CollectionName = collectionName;
      TypeOfChanges = typeOfChanges;
      RelatedChanges = relatedChanges;
    }

    public StudentListEventHandler() : this(collectionName: "Name",
                                            typeOfChanges: "Change",
                                            relatedChanges: new StudentTheThird())
    { }

    public override string ToString()
    {
      return CollectionName + ' ' + TypeOfChanges + ' ' + RelatedChanges.ToString();
    }
  }
}
