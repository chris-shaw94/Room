using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Room
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Start strt = new Start();
            strt.Init();
            strt.Run();
            Location cellar = new Location("A dank cellar", null, null);
            cellar.fill(Start.AvailableItems["key"], Start.AvailableItems["cup"], Start.AvailableItems["fluff"], null, null);
            cellar.directions("A stairs leading up to a door", "A blank wall", "A wall of barrels", "A wall with a light");
        }
    }
}
