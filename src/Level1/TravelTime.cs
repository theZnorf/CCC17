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
        private Vehicle vehicle;

        public TravelTime(Vehicle _vehicle, Location _srcLoc, Location _destLoc)
        {
            srcLoc = _srcLoc;
            destLoc = _destLoc;
            vehicle = _vehicle;
        }

        public double calcTravelTime()
        {
            var distance = srcLoc.distanceTo(destLoc);

            var travelTime = distance / vehicle.Speed;

            return travelTime;
        }
    }
}
