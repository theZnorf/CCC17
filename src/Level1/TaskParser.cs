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

        public List<Segment> TravelLocations { get; set; }

        public TaskParser(string path)
        {
            var lines = File.ReadAllLines(path);
            Locations = new List<Location>();
            TravelLocations = new List<Segment>();
            int numLocs = int.Parse(lines[0]);
            for (int i = 1; i <= numLocs; i++)
            {
                Locations.Add(new Location(lines[i]));
            }

            var fromToCar = lines[numLocs + 1].Split(' ');
            var journeyStart = Locations.First(x => x.Name.Equals(fromToCar[0]));
            var journeyEnd = Locations.First(x => x.Name.Equals(fromToCar[1]));
            
            var fromToHyperloop = lines[numLocs + 2].Split(' ');
            var nextStations = Locations.Where(x => x.Name.Equals(fromToHyperloop[0]) || x.Name.Equals(fromToHyperloop[1])).ToArray();
            if (nextStations[0].distanceTo(journeyStart) < nextStations[1].distanceTo(journeyStart))
            {
                TravelLocations.Add(new VehicleSegment(journeyStart, nextStations[0]));
                TravelLocations.Add(new HyperloopSegment(nextStations[0], nextStations[1]));
                TravelLocations.Add(new VehicleSegment(nextStations[1], journeyEnd));
            }
            else
            {
                TravelLocations.Add(new VehicleSegment(journeyStart, nextStations[1]));
                TravelLocations.Add(new HyperloopSegment(nextStations[1], nextStations[0]));
                TravelLocations.Add(new VehicleSegment(nextStations[0], journeyEnd));
            }
            
            Console.WriteLine($"{numLocs} Locations parsed:");
            foreach (var loc in Locations)
            {
                Console.WriteLine(loc.ToString());
            }
            foreach (var seg in TravelLocations)
            {
                Console.WriteLine(seg.ToString());
            }
        }
    }
}
