using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Player
    {
        public Location emptyRoom = new Location("");
        public Dictionary<string, Item> Inventory = new Dictionary<string, Item>();
        public List<Location> playerMap = new List<Location>();
        public Location currentRoom { get; set; }
        public int vcoord = 0;
        public int hcoord = 0;
        public int rnum = 0;
        public void look()
        {
            Console.Write(this.currentRoom.roomDescription);
            Console.WriteLine();
            if (this.currentRoom.exits["north"] != this.emptyRoom)
            {
                Console.WriteLine("To the north you see {0}", currentRoom.output[0].ToLower());
            }
            if (this.currentRoom.exits["south"] != this.emptyRoom)
            {
                Console.WriteLine("To the south you see {0}", currentRoom.output[1].ToLower());
            }
            if (this.currentRoom.exits["east"] != this.emptyRoom)
            {
                Console.WriteLine("To the east {0}", currentRoom.output[2].ToLower());
            }
            if (this.currentRoom.exits["west"] != this.emptyRoom)
            {
                Console.WriteLine("To the west you see {0}", currentRoom.output[3].ToLower());
            }
        }
        // An inventory check which should tell the user the items they're holding, followed by a description
        // bviously only want to print out descriptions of items the user has already picked up, rather than just
        // every item in the game. Would leaving the else part of this statement blank do that
        public void check()
        {
            foreach (KeyValuePair<string, Item> x in Inventory)
            {
                if (x.Value.inventval == 1)
                {
                    Console.WriteLine(x.Key, "{0}");
                    Console.Write(x.Value.description);
                    Console.WriteLine();
                }
                else
                {

                }
            }
        }
        public void take(string item)
        {
            string litem = item.ToLower().Replace("take ", "");

            // make sure the ventory is never null, this would cause an error
            if (Inventory == null)
                Inventory = new Dictionary<string, Item>();

            // if the item is in the inventory
            if (Inventory.ContainsKey(litem))
            {
                //if the inventory value is more than 0
                if (Inventory[litem].inventval != 0)
                {
                    Console.WriteLine("You're already carrying that.");
                }
                else
                {
                    Inventory[litem].inventval = 1;
                    Console.WriteLine("You pick up the ");
                    Console.WriteLine(litem);
                    currentRoom.contents.Remove(litem);
                    // inventory value is zero
                }
            }
            else
            // item not already in inventory
            // Should check to see if the room contains anything called litem and then  picks it up. It then removes the item from the list of contents.
            // else, if it's already been picked up, says it cannot see the item in the room.
            {
                {
                    Console.WriteLine("You cannot see a ");
                    Console.Write(litem);
                    Console.Write(" in the room");
                }
            }
        }
        public void go(string way)
        {
            if (this.currentRoom.exits[way] != this.emptyRoom)
            {
                if (this.currentRoom.RuleSet.ContainsKey(way))
                {
                    Console.WriteLine(this.currentRoom.RuleSet[way].RuleDescription);
                }
                else
                {
                    this.currentRoom = this.currentRoom.exits[way];
                }
            }
        }
        public void use(string command)
        {
            string luse = command.ToLower().Replace("use ", "");
            foreach (KeyValuePair<string, Rule> k in this.currentRoom.RuleSet)
            {
                if(k.Value.Requirement == luse && Inventory[luse].inventval != 0)
                {
                    currentRoom.RuleSet.Remove(k.Key);
                    Console.WriteLine("You use the ");
                    Console.Write(luse);
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("That doesn't work");
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
                case "north":
                    this.go(lcomm);
                    this.look();
                    break;
                case "south":
                    this.go(lcomm);
                    this.look();
                    break;
                case "east":
                    this.go(lcomm);
                    this.look();
                    break;
                case "west":
                    this.go(lcomm);
                    this.look();
                    break;
                case "s":
                    break;
                case "use":
                    this.use(lcomm);
                    break;
                default:
                    Console.WriteLine("Sorry didn't recognise command");
                    Console.WriteLine("Commands: look, take, check, use ____, q-quit");
                    Console.WriteLine("Directional commands: north, south, east, west");
                    break;
            }
        }
    }
}