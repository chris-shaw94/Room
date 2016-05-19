using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Player
    {
        List<Item> Inventory = new List<Item>();
        public string action(string command)
        {
            string lcommand = command.ToLower();
            switch (lcommand)
            {
                case "pick up key":
                    if(Item.key.inventval == 0) { }
            }
    }
}
