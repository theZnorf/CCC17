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

            int begin = locList.IndexOf(fromStation);
            int end = locList.IndexOf(toStation);

            if (begin > end)
            {
                locList.Reverse();
            }

            var locations = locList.SkipWhile(x => x != fromStation).TakeWhile(x => x != toStation);

            var drivenSegments = new List<Segment>();
            var prev = locations.First();
            drivenSegments.Add(new VehicleSegment(From, prev));
            foreach (var seg in locations.Skip(1))
            {
                drivenSegments.Add(new HyperloopSegment(prev, seg));
                prev = seg;
            }
            drivenSegments.Add(new HyperloopSegment(prev, toStation));
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
