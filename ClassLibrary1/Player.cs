using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Player
    {
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
            if (this.currentRoom.exits[0] != "")
            {
                Console.WriteLine("To the north you see {0}", currentRoom.exits[0]);
            }
            if (this.currentRoom.exits[1] != "")
            {
                Console.WriteLine("To the south you see {0}", currentRoom.exits[1]);
            }
            if (this.currentRoom.exits[2] != "")
            {
                Console.WriteLine("To the east {0}", currentRoom.exits[2]);
            }
            if (this.currentRoom.exits[3] != "")
            {
                Console.WriteLine("To the west you see {0}", currentRoom.exits[3]);
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
                    Console.WriteLine(x.Key);
                    Console.Write(", ");
                    Console.Write(x.Value.description);
                }
                else
                {

                }
            }
        }
        public void go(string way)
        {
            switch (way)
            {
                case "n":
                    if ((this.hcoord == -1 && this.vcoord == 0) || (this.hcoord == 0 && this.vcoord == -1))
                    {
                    }
                    else
                    {
                        this.vcoord = this.vcoord + 1;
                    }
                    if(this.vcoord == 2)
                    {
                        this.vcoord = 1;
                    }                    
                    break;
                case "s":
                    if ((hcoord == 0 && this.vcoord == 0) || (this.hcoord == -1 && this.vcoord == 1))
                    {
                    }
                    else
                    {
                        this.vcoord = this.vcoord - 1;
                    }
                    if(this.vcoord == -2)
                    {
                        this.vcoord = -1;
                    }
                    break;
                case "w":
                    if ((hcoord == 0 && this.vcoord == 0) || (this.hcoord == 1 && this.vcoord == 0))
                    {
                    }
                    else
                    {
                        this.hcoord = this.hcoord - 1;
                    }
                    if(this.hcoord == -2)
                    {
                        this.hcoord = -1;
                    }
                    break;
                case "e":
                    if ((hcoord == 0 && this.vcoord == 0) || (this.hcoord == -1 && this.vcoord == 0))
                    {
                    }
                    else
                    {
                        this.hcoord = this.hcoord + 1;
                    }
                    if(this.hcoord == 2)
                    {
                        this.hcoord = 1;
                    }
                    break;
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
                if (Inventory[item].inventval != 0)
                {
                    Console.WriteLine("You're already carrying that.");
                }
                else
                {
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
        public void place(int v, int h)
        {
            switch (v)
            {
                case 0:
                    switch (h)
                    {
                        case 0:
                            this.rnum = 0;
                            break;
                        case 1:
                            this.rnum = 1;
                            break;
                        case -1:
                            this.rnum = 2;
                            break;
                    }
                    break;
                case 1:
                    switch (h)
                    {
                        case 0:
                            this.rnum = 3;
                            break;
                        case 1:
                            this.rnum = 4;
                            break;
                        case -1:
                            this.rnum = 5;
                            break;
                    }
                    break;
                case -1:
                    switch (h)
                    {
                        case 0:
                            this.rnum = 6;
                            break;
                        case 1:
                            this.rnum = 7;
                            break;
                        case -1:
                            this.rnum = 8;
                            break;
                    }
                    break;
            }
        }
        public void where()
        {
            for (int i = 0; i < this.playerMap.Count; i++)
            {
                if(this.rnum == i)
                {
                    this.currentRoom = this.playerMap[i];
                }
            }
        }
        public void locat()
        {
            this.place(this.vcoord, this.hcoord);
            this.where();
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
                    this.go("n");
                    this.locat();
                    this.look();
                    break;
                case "south":
                    this.go("s");
                    this.locat();
                    this.look();
                    break;
                case "east":
                    this.go("e");
                    this.locat();
                    this.look();
                    break;
                case "west":
                    this.go("w");
                    this.locat();
                    this.look();
                    break;
                case "s":
                    break;
                default:
                    Console.WriteLine("Sorry didn't recognise command");
                    Console.WriteLine("Commands: look, take, check, q-quit");
                    Console.WriteLine("Directional commands: north, south, east, west");
                    break;
            }
        }
    }
}