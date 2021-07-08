namespace Övning5
{
    public class Vehicle : IVehicle
    {
        private string id;
        private string color;
        private int wheels;

        public string Id { get; private set; }
        public string Color { get; private set; }
        public int Wheels { get; private set; }

        public int ParkingSpot = -1;

        public Vehicle(string id, string color, int wheels)
        {
            this.Id = id;
            this.Color = color;
            this.Wheels = wheels;
        }

        public override string ToString()
        {
            return $"Vehicle has id{Id}, color{Color} and wheels{Wheels} it is parked at {ParkingSpot} (if -1 it is not parked)";
        }
    }
}