using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Player
    {
        public Dictionary<string,Item> Inventory = new Dictionary <string, Item>();
        Location currentRoom { get; set; }

        public void itemCheck(string item)
        {
            if (Inventory != null && (Inventory[item] == null || Inventory[item].inventval == 0))
            {
                Inventory.Add(item, new Item(item, 0));
                Inventory[item].inventval = 1;
                Console.WriteLine("You pick up the ");
                Console.Write(item);
            }
            else
            {
                Console.WriteLine("You already did that");
            }
        }
        public void look()
        {
            Console.WriteLine(currentRoom.roomDescription);
            Console.WriteLine("To the north you see currentRoom.exits[0]");
            Console.WriteLine("To the south you see currentRoom.exits[1]");
            Console.WriteLine("To the east you see currentRoom.exits[2]");
            Console.WriteLine("To the west you see currentRoom.exits[3]");
        }
        public void check()
        {
            foreach(KeyValuePair<string, Item> x in Inventory)
            {
                Console.WriteLine(x.Value);
                Console.Write(" ");
                Console.Write(x.Key);
            }
        }
        public void take(string item)
        {
            string litem = item.ToLower();
            switch (litem)
            {
                case "key":
                    itemCheck("key");
                    break;
                case "cup":
                    itemCheck("cup");
                    break;
                case "fluff":
                    itemCheck("fluff");
                    break;
                default:
                    break;
            }
        }
        public void command(string comm)
        {
            string lcomm = comm.ToLower();
            switch (lcomm)
            {
                case "look":
                    this.look();
                    break;
                case "check inventory":
                    this.check();
                    break;
                case "take":
                    if(lcomm.Contains("take")&&lcomm.Contains("key"))
                    {
                        take("key");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Take what?");
                        break;
                    }
                default:
                    break;
            }
        }
    }
}