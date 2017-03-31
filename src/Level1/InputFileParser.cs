using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1
{

    public class TaskParser
    {
        public List<Location> Locations { get; set; }
        public Location From { get; set; }
        public Location To { get; set; }

        public TaskParser(string path)
        {
            var lines = File.ReadAllLines(path);
            Locations = new List<Location>();
            int numLocs = int.Parse(lines[0]);
            for (int i = 1; i <= numLocs; i++)
            {
                Locations.Add(new Location(lines[i]));
            }

            var fromTo = lines[numLocs + 1].Split(' ');
            From = Locations.First(x => x.Name.Equals(fromTo[0]));
            To = Locations.First(x => x.Name.Equals(fromTo[1]));
        }
    }
}
