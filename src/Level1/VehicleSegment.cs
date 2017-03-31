namespace Level1
{
    public class VehicleSegment : Segment
    {
        public Vehicle Vehicle { get; private set; }
        public VehicleSegment(Location from, Location to) : base(from, to)
        {
            Vehicle = new Vehicle(15);
        }
        public override double Duration => new TravelTime(Vehicle, From, To).calcTravelTime();
    }
}
