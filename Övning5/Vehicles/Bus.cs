namespace Övning5
{
    internal class Bus : Vehicle
    {
        public Bus(string id, string color, int wheels, string fuelType) : base(id, color, wheels)
        {
            Id = id;
            Color = color;
            Wheels = wheels;
            FuelType = fuelType;
        }

        public string Id { get; }
        public string Color { get; }
        public int Wheels { get; }
        public string FuelType { get; }
    }
}