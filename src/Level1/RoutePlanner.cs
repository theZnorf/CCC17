using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1
{
    public class RoutePlanner
    {
        private Segment enclosed;
        private Location From;
        private Location To;

        public RoutePlanner(Segment enclodedSeg, Location from, Location to)
        {
            enclosed = enclodedSeg;
            From = from;
            To = to;
        }

        public double calcJourneyTime()
        {
            List<Location> locList = new List<Location>();
            locList.Add(enclosed.From);
            locList.Add(enclosed.To);

            var fromStation = getNearest(From, locList);
            var toStation = getNearest(To, locList);

            List<Segment> segments = new List<Segment>();

            segments.Add(new VehicleSegment(From, fromStation));
            segments.Add(enclosed);
            segments.Add(new VehicleSegment(toStation, To));

            var totalTime = Math.Round(segments.Sum(x => x.Duration));

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
