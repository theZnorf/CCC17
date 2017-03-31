using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1
{
    public class RoutePlanner
    {
        private List<Segment> Segments;
        private Location From;
        private Location To;

        public RoutePlanner(List<Segment> segments, Location from, Location to)
        {
            Segments = new List<Segment>(segments);
            From = from;
            To = to;
        }

        public double calcJourneyTime()
        {
            List<Location> locList = new List<Location>();

            foreach (var seg in Segments)
            {
                locList.Add(seg.From);
            }
            locList.Add(Segments.Last().To);

            var fromStation = getNearest(From, locList);
            var toStation = getNearest(To, locList);

            var firstHyperSeg = Segments.First(x => x.From == fromStation);
            var lastHyperSeg = Segments.First(x => x.To == toStation);

            List<Segment> drivenSegments = new List<Segment>();

            drivenSegments.Add(new VehicleSegment(From, fromStation));

            drivenSegments.Add(firstHyperSeg);
            Segments.Skip(Segments.IndexOf(firstHyperSeg));
            drivenSegments.AddRange(Segments.TakeWhile(x => x != lastHyperSeg));
            drivenSegments.Add(lastHyperSeg);

            drivenSegments.Add(new VehicleSegment(toStation, To));

            var totalTime = Math.Round(drivenSegments.Sum(x => x.Duration));

            Console.WriteLine($"Total time: {totalTime}");

            return (int)totalTime;
        }

        private Location getNearest(Location start, List<Location> locList)
        {
            Location nearest = locList.First();
            foreach (var loc in locList)
            {
                if (start.distanceTo(loc) < start.distanceTo(nearest))
                {
                    nearest = loc;
                }
            }
            return nearest;
        }

    }
}
