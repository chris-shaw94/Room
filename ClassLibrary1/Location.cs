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
        public Dictionary<string, Location> exits;
        public List<string> output;
        public Location(string descript, List<string> content, Dictionary<string, Location> exit, List<string> output)
        {

            this.roomDescription = descript;
            this.contents = content;
            this.exits = exit;
            this.output = output;
        }
        public void fill(string a)
        {
            this.contents.Add(a);
        }
        public void directions(Location n, Location s, Location e, Location w)
        {
            this.exits.Add("north", n);
            this.exits.Add("south", s);
            this.exits.Add("east", e);
            this.exits.Add("west", w);
        }
        public void oput(string n, string s, string e, string w)
        {
            this.output.Add(n);
            this.output.Add(s);
            this.output.Add(e);
            this.output.Add(w);
        }
    }
}
