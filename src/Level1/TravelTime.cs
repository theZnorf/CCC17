using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Level1
{
    class TravelTime
    {
        private Location srcLoc;
        private Location destLoc;
        private Train train;

        public TravelTime(Train _train, Location _srcLoc, Location _destLoc)
        {
            srcLoc = _srcLoc;
            destLoc = _destLoc;
            train = _train;
        }

        public int calcTravelTime()
        {
            var distance = srcLoc.distanceTo(destLoc);

            System.Console.WriteLine($"TravelTime: calculated distance: {distance}");

            var travelTime = distance / train.Speed;

            System.Console.WriteLine($"TravelTime: calculated traveltime without stop: {travelTime}");

            var totalTime = travelTime + srcLoc.StopSeconds;

            System.Console.WriteLine($"TravelTime: calculated total travel time with stop: {totalTime}");

            int result = (int)Math.Ceiling(totalTime);

            System.Console.WriteLine($"TravelTime: rounded total time: {totalTime}");

            return result;
        }
    }
}
