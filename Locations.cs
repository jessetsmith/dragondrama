using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DragonDrama
{
    class Locations
    {
        public string Location { get; set; }
        public List<string> Exits { get; set; }

        public Locations(string location, List<string> exits)
        {
            Location = location;
            Exits = exits;
        }
    }
}
