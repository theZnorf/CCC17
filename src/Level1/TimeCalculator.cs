using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1
{
    class TimeCalculator
    {
        private List<Location> locationList;
        private Train train;

        public TimeCalculator(List<Location> locations)
        {
            locationList = locations;

            train = new Train();
        }

        public int calcTime(Location srcLoc, Location destLoc)
        {
            var time = new TravelTime(train, srcLoc, destLoc);

            return time.calcTravelTime();
        }
    }
}
