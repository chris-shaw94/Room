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
        public List<Item> contents;
        public List<string> exits;
        public Location(string descript, List<Item> content, List<string> exit)
        {
            this.roomDescription = descript;
            this.contents = content;
            this.exits = exit;
        }
        public void fill(Item a, Item b, Item c, Item d, Item e)
        {
            this.contents.Add(a);
            this.contents.Add(b);
            this.contents.Add(c);
            this.contents.Add(d);
            this.contents.Add(e);
        }
        public void directions(string n, string s, string e, string w)
        {
            this.exits.Add(n);
            this.exits.Add(s);
            this.exits.Add(e);
            this.exits.Add(w);
        }
    }
}
