using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Player
    {
        public Dictionary<string,Item> Inventory = new Dictionary <string, Item>();
        Room currentRoom { get; set; }

        public string look()
        {
            Console.WriteLine(Room.roomDescription);
        }
        public string take(string item)
        {
            string litem = item.ToLower();
            switch (litem)
            {
                case "key":
                    break;

            }
        }
    }
}
