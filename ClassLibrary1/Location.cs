using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Location
    {
        public string roomDescription;
        public List<string> contents;
        public Dictionary<string,Location> exits;
        public Location(string descript, List<string> content, Dictionary<string, Location> exit) { 
        
            this.roomDescription = descript;
            this.contents = content;
            this.exits = exit;
        }
        public void fill(string a)
        {
            this.contents.Add(a);
        }
        public void directions(List<KeyValuePair<string, Location>> locations)
        {
            foreach (KeyValuePair<string, Location> kvp in locations)
            {
                this.exits.Add(kvp.Key,kvp.Value);
            }
        }

    }
}
