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

        //Not sure if I need this itemCheck function any more?
        //At least, not if take() is working properly.
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
        // An inventory check which should tell the user the items they're holding, followed by a description
        // Obviously only want to print out descriptions of items the user has already picked up, rather than just
        // every item in the game. Would leaving the else part of this statement blank do that?
        public void check()
        {
            foreach(KeyValuePair<string, Item> x in Inventory)
            {   if (x.Value.inventval == 1)
                {
                    Console.WriteLine(x.Key);
                    Console.Write(", ");
                    Console.Write(x.Value.description);
                }
                else
                {
                    
                }
            }
        }
        public void take(string item)
        {
            string litem = item.ToLower().Replace("take ","");

            // make sure the inventory is never null, this would cause an error
            if (Inventory == null)
                Inventory = new Dictionary<string, Item>();

            // if the item is in the inventory
            if (Inventory.ContainsKey(litem))
            {
                //if the inventory value is more than 0
                if(Inventory[item].inventval!=0)
                {
                    Console.WriteLine("You're already carrying that.");
                }
                else
                {
                    Inventory[litem].inventval = 1;
                    // inventory value is zero
                }
            }
            else
            // item not already in inventory
            // Should check to see if the room contains anything called litem and then  picks it up. It then removes the item from the list of contents.
            // else, if it's already been picked up, says it cannot see the item in the room.
            {
                if (currentRoom.contents.Contains(litem))
                {
                    Inventory[item].inventval = 1;
                    Console.WriteLine("You pick up the ");
                    Console.Write(litem);
                    currentRoom.contents.Remove(litem);
                }
                else
                {
                    Console.WriteLine("You cannot see a ");
                    Console.Write(litem);
                    Console.Write(" in the room");
                }
            }
        }
        public void command(string comm)
        {
            string lcomm = comm.ToLower();

            // this creates an array which is another type of list and breaks the command up into the commands entered by the player
            string[] commands = lcomm.Split(' ');

            // this looks at the first command the player entered
            switch (commands[0])
            {
                case "look":
                    this.look();
                    break;
                case "check":
                    this.check();
                    break;
                case "take":
                    this.take(lcomm);
                    break;
                default:
                    Console.WriteLine("Sorry didn't recognise command");
                    Console.WriteLine("look, take, check, q-quit");
                    break;
            }
        }
    }
}