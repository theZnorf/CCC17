using System;

namespace Level1
{
    public class Location
    {
        private string v;

        public Location(string v)
        {
            var parts = v.Split(' ');
            Name = parts[0];
            LocX = int.Parse(parts[1]);
            LocY = int.Parse(parts[2]);
        }

        public string Name { get; set; }
        public int LocX { get; set; }
        public int LocY { get; set; }

        public int StopSeconds { get; set; }

        public double distanceTo(Location other)
        {
            double xDist = Math.Abs(LocX - other.LocX);
            double yDist = Math.Abs(LocY - other.LocY);
            return Math.Sqrt(xDist * xDist + yDist * yDist);
        }
    }
}
