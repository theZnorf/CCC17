using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1
{
    class TimeCalculator
    {
        private Train train;

        public TimeCalculator()
        {
            train = new Train();
        }

        public int calcTime(Location srcLoc, Location destLoc)
        {
            Console.WriteLine($"TimeCalculator: calc time between {srcLoc} and {destLoc}");
            var time = new TravelTime(train, srcLoc, destLoc);
            return time.calcTravelTime();
        }
    }
}
