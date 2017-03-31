namespace Level1
{
    public abstract class Segment
    {
        public Segment(Location from, Location to)
        {
            From = from;
            To = to;
        }

        public Location From { get; set; }
        public Location To { get; set; }
        public abstract double Duration { get; }
    }
}
