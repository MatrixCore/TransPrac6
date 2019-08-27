// Handle cross reference table for Parva
// P.D. Terry, Rhodes University, 2016

using Library;
using System.Collections.Generic;
using System.Text;

namespace Parva {

  class Entry {                      // Cross reference table entries
    public string name;              // The identifier itself
    public List<int> refs;           // Line numbers where it appears
    public Entry(string name) {
      this.name = name;
      this.refs = new List<int>();
    }
  } // Entry

  class Table {
    static List<Entry> list = new List<Entry>();

    public static void ClearTable() {
            list.Clear(); 
    } // Table.ClearTable

    public static void AddRef(string name, bool declared, int lineRef) {
            declared = false;
            foreach (Entry item in list)
            {
                if (item.name == name)
                {
                    declared = true;
                    if (item.refs.Contains(lineRef) != true) //check to see if the line reference has already been included
                    {
                        item.refs.Add(lineRef);
                    }
                    
                }
            }
            if (declared != true)
            {
                Entry toAdd = new Entry(name);
                toAdd.refs.Add( (lineRef * -1) );
                list.Add(toAdd); 
            }
            
            // Enters name if not already there, and then adds another line reference (negative
            // if at a declaration point in the original source program)
            // ...
        } // Table.AddRef

    public static void PrintTable() {
            foreach (Entry item in list)
            {
                IO.Write($"{item.name}\t\t");
                foreach (int vary in item.refs)
                {
                    IO.Write($"{vary}   "); 
                }
                IO.WriteLine(); 
            }

    // Prints out all references in the table (eliminate duplicates line numbers)
    //...
    } // Table.PrintTable

  } // Table

} // namespace
