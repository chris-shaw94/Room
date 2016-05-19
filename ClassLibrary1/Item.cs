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
        public string itemCheck(string item)
        {
            if (Player.Inventory != null && (Player.Inventory[item] == 0 || Player.Inventory[item].inventval == 0))
            {
                Player.Inventory.Add(item, new Item("It's a key. Perfect for a lock", 0));
                Player.Inventory[item].inventval = 1);
                Console.WriteLine("You pick up the ");
                Console.Write(item);
                break;
            }
            else
            {
                Console.WriteLine("You already did that");
            }
            break;
        }
    }
}
