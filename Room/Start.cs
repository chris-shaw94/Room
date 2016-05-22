using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Room
{
    public class Start
    {
        public static Dictionary<string, Item> AvailableItems { get; set; }
        public static List<Location> Map { get; set; }
        private Player _character { get; set; }
        public Player yourCharacter
        {
            get
            {
                return this._character;
            }
            set
            {
                this._character = value;
            }
        }
        /// <summary>
        /// We'll use this function to load up your values that you'll need
        /// </summary>
        public void Init()
        {
            Map = new List<Location>();
            AvailableItems = new Dictionary<string, Item>();
            AvailableItems.Add("key", new Item("It's a key. Perfect for a lock", 0));
            AvailableItems.Add("fluff", new Item("Some useless fluff left in your pocket", 1));
            AvailableItems.Add("cup", new Item("A cup. Unfortunately empty", 0));
            
            Run();
        }
        public void where()
        {
            if (yourCharacter.rnum == 0)
            {
                yourCharacter.currentRoom = Start.Map[0];
            }
            else if (yourCharacter.rnum == 1)
            {
                yourCharacter.currentRoom = Start.Map[4];
            }
            else if (yourCharacter.rnum == 2)
            {
                yourCharacter.currentRoom = Start.Map[8];
            }
            else if (yourCharacter.rnum == 3)
            {
                yourCharacter.currentRoom = Start.Map[1];
            }
            else if (yourCharacter.rnum == 4)
            {
                yourCharacter.currentRoom = Start.Map[3];
            }
            else if (yourCharacter.rnum == 5)
            {
                yourCharacter.currentRoom = Start.Map[2];
            }
            else if (yourCharacter.rnum == 6)
            {
                yourCharacter.currentRoom = Start.Map[6];
            }
            else if (yourCharacter.rnum == 7)
            {
                yourCharacter.currentRoom = Start.Map[5];
            }
            else if (yourCharacter.rnum == 8)
            {
                yourCharacter.currentRoom = Start.Map[7];
            }
        }
        // heres where we will kick off your game properly
        public void Run()
        {
            Player yourCharacter = new Player();

            Location cellar = new Location("You're standing in an uncomfortably damp cellar", new List<string>(), new List<string>());
            cellar.fill("key");
            cellar.fill("cup");
            cellar.fill("fluff");
            cellar.directions("a stairs leading up to a door", "", "", "");
            Map.Add(cellar);

            Location kitchen = new Location("You're in a brightly lit kitchen", new List<string>(), new List<string>());
            kitchen.directions("", "a stairs leading to a dark cellar", "a door to the hall", "a set of double doors");
            Map.Add(kitchen);
            Location diningRoom = new Location("A large dining room with a long, oak table", new List<string>(), new List<string>());
            diningRoom.directions("", "", "the doors back to the kitchen", "");
            Map.Add(diningRoom);
            Location sittingRoom = new Location("You are relaxing in a fully furnished sitting room", new List<string>(), new List<string>());
            sittingRoom.directions("", "a set of glass double doors into a conservatory", "", "the door to the kitchen");
            Map.Add(sittingRoom);
            Location conservatory = new Location("You are standing in a very relaxing conservatory", new List<string>(), new List<string>());
            sittingRoom.directions("a set of glass double doors", "a small door", "", "");
            Map.Add(conservatory);
            Location hall = new Location("You find yourself standing in a hallway", new List<string>(), new List<string>());
            hall.directions("a small door", "", "", "a stairway leading up");
            Map.Add(hall);
            Location landing = new Location("You're on the landing of a stairway", new List<string>(), new List<string>());
            landing.directions("", "", "the stairs down to the hall", "a bedroom door");
            Map.Add(landing);
            Location bedroom = new Location("You find yourself in what looks like an old woman's bedroom", new List<string>(), new List<string>());
            bedroom.directions("a small, shabby door", "", "the door back to the landing", "");
            Map.Add(bedroom);
            Location toilet = new Location("A bathroom with a weird, rotting smell", new List<string>(), new List<string>());
            toilet.directions("", "a door back to the bedroom", "", "");
            Map.Add(toilet);

            foreach (KeyValuePair<string, Item> o in AvailableItems)
            {
                yourCharacter.Inventory.Add(o.Key, o.Value);
            }
            Console.WriteLine("Welcome to the awesome game");
            Console.WriteLine("Press s to start");
            Console.WriteLine("Press q to quit");
            while (true)
            {
                string cmd = Console.ReadLine().ToLower();

                if (cmd == "q")
                    break;
                if (cmd == "s")
                {
                    yourCharacter.look();
                }
                // this passes the command into the player class
                yourCharacter.command(cmd);


            }
            Console.WriteLine("Thanks for playing");
            Console.WriteLine("press enter");
            Console.ReadLine().ToLower();
        }
    }
}
