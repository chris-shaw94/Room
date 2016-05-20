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
        public static Player yourCharacter{ get; set; }

        /// <summary>
        /// We'll use this function to load up your values that you'll need
        /// </summary>
        public void Init()
        {
            AvailableItems = new Dictionary<string, Item>();
            AvailableItems.Add("key", new Item("It's a key. Perfect for a lock", 0));
            AvailableItems.Add("fluff", new Item("Some useless fluff left in your pocket", 1));
            AvailableItems.Add("cup", new Item("A cup. Unfortunately empty", 0));

            Location cellar = new Location("A dank cellar", new List<string>(), new List<string>());
            cellar.fill("key");
            cellar.fill("cup");
            cellar.fill("fluff");
            cellar.directions("A stairs leading up to a door", "A blank wall", "A wall of barrels", "A wall with a light");

            yourCharacter = new Player();
        }

        // heres where we will kick off your game properly
        public void Run()
        {

            while(true)
            {

                Console.WriteLine("Welcome to the awesome game");
                Console.WriteLine("Press s to start");
                Console.WriteLine("Press q to quit");
                string cmd = Console.ReadLine().ToLower();

                if (cmd == "q")
                    break;

                // this passes the command into the player class
                yourCharacter.command(cmd);


            }

            Console.WriteLine("Thanks for playing");
            Console.WriteLine("press enter");
            Console.ReadLine().ToLower();
        }
    }
}
