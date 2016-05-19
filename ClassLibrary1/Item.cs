using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Item
    {
        string description;
        int inventval;
        public void createItem(string description, public int inventval)
        {
            this.description = description;
            this.inventval = inventval;
        }
        public static Item key = Item.createItem("It's a key. Perfect for a lock", 0);
        public static Item fluff = Item.createItem("Some useless fluff left in your pocket", 1);
        public static Item cup = Item.createItem("A cup. Unfortunately empty", 0);

    }
}
