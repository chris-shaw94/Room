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

        /// <summary>
        /// We'll use this function to load up your values that you'll need
        /// </summary>
        public void Init()
        {
            AvailableItems = new Dictionary<string, Item>();
            AvailableItems.Add("key", new Item("It's a key. Perfect for a lock", 0));
            AvailableItems.Add("fluff", new Item("Some useless fluff left in your pocket", 1));
            AvailableItems.Add("cup", new Item("A cup. Unfortunately empty", 0));

            Location cellar = new Location("A dank cellar", null, null);
            cellar.fill(AvailableItems["key"], AvailableItems["cup"], AvailableItems["fluff"], null, null);
            cellar.directions("A stairs leading up to a door", "A blank wall", "A wall of barrels", "A wall with a light");
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
            }

            Console.WriteLine("Thanks for playing");
            Console.WriteLine("press enter");
            Console.ReadLine().ToLower();
        }
    }
}
