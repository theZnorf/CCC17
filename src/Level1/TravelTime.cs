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

            var travelTime = distance / train.Speed;

            var totalTime = travelTime + srcLoc.StopSeconds;

            return (int)Math.Round(totalTime);
        }
    }
}
