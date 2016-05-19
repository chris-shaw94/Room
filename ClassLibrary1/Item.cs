using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Item
    {
        public string description;
        public int inventval;
        public Item(string description, int inventval)
        {
            this.description = description;
            this.inventval = inventval;
        }

    }
}
