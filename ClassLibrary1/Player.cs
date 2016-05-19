using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Player
    {
        Dictionary<string,Item> Inventory = new Dictionary <string, Item>();

        public string action(string command)
        {
            string lcommand = command.ToLower();
            switch (lcommand)
            {
                case "pick up key":
                    // if the inventory isnt null AND there is a record for key is null OR the invent val for the key record is 0
                    if (Inventory != null && (Inventory["key"] == null || Inventory["key"].inventval == 0))
                    {
                    }
                    break;
            }

            return "";
        }
    }
}
