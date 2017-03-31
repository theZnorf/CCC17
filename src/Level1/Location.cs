using System;

namespace Level1
{
    public class Location
    {
        private string v;

        public Location(string v)
        {
            StopSeconds = 200;

            var parts = v.Split(' ');
            Name = parts[0];
            LocX = int.Parse(parts[1]);
            LocY = int.Parse(parts[2]);
        }

        public string Name { get; set; }
        public int LocX { get; set; }
        public int LocY { get; set; }

        public int StopSeconds { get; private set; }

        public double distanceTo(Location other)
        {
            double xDist = Math.Abs(LocX - other.LocX);
            double yDist = Math.Abs(LocY - other.LocY);
            var dist = Math.Sqrt(xDist * xDist + yDist * yDist);
            Console.WriteLine($"Distance between {Name} and {other.Name} is {dist}");
            return dist;
        }

        public override string ToString()
        {
            return $"{Name} ({LocX}, {LocY})";
        }
    }
}
