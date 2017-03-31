using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1
{

    public class Journey
    {
        public Journey(Location from, Location to)
        {
            From = from;
            To = to;
        }

        public Location From { get; set; }
        public Location To { get; set; }
    }

    public class TaskParser
    {
        public List<Location> Locations { get; set; }

        public Journey Journey { get; set; }
        public List<Segment> Segments { get; set; }

        public TaskParser(string path)
        {
            int line = 0;
            var lines = File.ReadAllLines(path);
            Locations = new List<Location>();
            Segments = new List<Segment>();
            int numLocs = int.Parse(lines[line++]);
            for (; line <= numLocs; line++)
            {
                Locations.Add(new Location(lines[line]));
            }

            // Console.WriteLine("Parsing journeys:");
            // int numJourneys = int.Parse(lines[line++]);
            // for (int i = 0; i < numJourneys; i++)
            // {
            var journeyString = lines[line++];
            var parts = journeyString.Split(' ');
            var s = parts[0]; var e = parts[1]; // var cd = parts[2];
            Journey = new Journey(Locations.First(x => x.Name.Equals(s)), Locations.First(x => x.Name.Equals(e)));
            // }

            var hyperloopParts = lines[line].Split(' ');
            var numHyperLoopStations = int.Parse(hyperloopParts[0]);
            var from = Locations.First(x => x.Name.Equals(hyperloopParts[1]));
            for (int i = 2; i <= numHyperLoopStations; i++)
            {
                var to = Locations.First(x => x.Name.Equals(hyperloopParts[i]));
                Segments.Add(new HyperloopSegment(from, to));
                from = to;
            }

            // var hyperloopSegment = lines[line];
            // var segPart = hyperloopSegment.Split(' ');
            // HyperloopSegment = new HyperloopSegment(Locations.First(x => x.Name.Equals(segPart[0])), Locations.First(x => x.Name.Equals(segPart[1])));
        }
    }
}
