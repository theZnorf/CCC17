namespace Level1
{
    public class HyperloopSegment : Segment
    {
        public Vehicle Vehicle { get; private set; }
        public HyperloopSegment(Location from, Location to) : base(from, to)
        {
            Vehicle = new Vehicle(250);
        }

        public override double Duration => new TravelTime(Vehicle, From, To).calcTravelTime() + From.StopSeconds;
    }
}
