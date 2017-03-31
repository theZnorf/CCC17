using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1
{
    public class RouteGenerator
    {
        private List<Location> locations;
        private int maxLength;

        public RouteGenerator(List<Location> locList, int maxLen)
        {
            locations = locList;
            maxLength = maxLen;
        }

        public List<Segment> generateRoute()
        {
            List<Segment> route = new List<Segment>();
            var rand = new Random();

            Location from = locations.ElementAt(rand.Next());
            var other = locations.Where(x => x != from);
            Location to = other.ElementAt(rand.Next());
            
            double length = 0;
            double newLength = from.distanceTo(to);

            while(length + newLength < maxLength)
            {
                route.Add(new HyperloopSegment(from, to));
                length += newLength;
                from = other.ElementAt(rand.Next());
                other = other.Where(x => x != from);
                to = other.ElementAt(rand.Next());
                newLength = from.distanceTo(to);
            }

            return route;
        }
    }
}
