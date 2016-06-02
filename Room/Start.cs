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

            _character = new Player();

            Location cellar = new Location("You're standing in an uncomfortably damp cellar");
            _character.currentRoom = cellar;
            cellar.oput("A stairs leading up","","",""); 
            foreach (KeyValuePair<string, Item> o in AvailableItems)
            {
                _character.Inventory.Add(o.Key, o.Value);
            }


            Location kitchen = new Location("You're in a brightly lit kitchen");
            kitchen.oput("", "A stairs leading down", "A door", "A set of double doors");

            Location diningRoom = new Location("A large dining room with a long, oak table");
            diningRoom.oput("", "", "A door", "");

            Location sittingRoom = new Location("You are relaxing in a fully furnished sitting room");
            sittingRoom.oput("", "A set of glass double doors", "", "A door to the kitchen");

            Location conservatory = new Location("You are standing in a very relaxing conservatory");
            conservatory.oput("The glass doors to the sitting room", "A small door", "", "");

            Location hall = new Location("You find yourself standing in a hallway");
            hall.oput("A small door","", "","Some stairs");

            Location landing = new Location("You're on the landing of a stairway");
            landing.oput("","","The stairs", "A bedroom door");

            Location bedroom = new Location("You find yourself in what looks like an old woman's bedroom");
            bedroom.oput("A toilet door", "", "The landing door", "");

            Location toilet = new Location("A bathroom with a weird, rotting smell");
            toilet.oput("", "", "", "");

            cellar.directions(kitchen, yourCharacter.emptyRoom , yourCharacter.emptyRoom , yourCharacter.emptyRoom);
            cellar.RuleSet.Add("north", new Rule() { RuleDescription="The door is locked", Requirement = "key" });

            kitchen.directions(yourCharacter.emptyRoom, cellar, sittingRoom, diningRoom);
            diningRoom.directions(yourCharacter.emptyRoom, yourCharacter.emptyRoom, kitchen, yourCharacter.emptyRoom);
            sittingRoom.directions(yourCharacter.emptyRoom, conservatory, yourCharacter.emptyRoom, kitchen);
            conservatory.directions(sittingRoom, hall, yourCharacter.emptyRoom, yourCharacter.emptyRoom);
            hall.directions(conservatory, yourCharacter.emptyRoom, yourCharacter.emptyRoom, landing);
            landing.directions(yourCharacter.emptyRoom, yourCharacter.emptyRoom, hall, bedroom);
            bedroom.directions(toilet, yourCharacter.emptyRoom, landing, yourCharacter.emptyRoom);
            toilet.directions(yourCharacter.emptyRoom, bedroom, landing, yourCharacter.emptyRoom);
            if (_character.playerMap.Count < 9)
            {
                _character.playerMap.Add(cellar);
                _character.playerMap.Add(conservatory);
                _character.playerMap.Add(toilet);
                _character.playerMap.Add(kitchen);
                _character.playerMap.Add(sittingRoom);
                _character.playerMap.Add(diningRoom);
                _character.playerMap.Add(landing);
                _character.playerMap.Add(hall);
                _character.playerMap.Add(bedroom);
            }
            
            Run();
        }
        // heres where we will kick off your game properly
        public void Run()
        {

            
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