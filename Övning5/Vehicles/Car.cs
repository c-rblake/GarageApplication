namespace Övning5
{
    internal class Car : Vehicle
    {
        public Car(string id, string color, int wheels, int numberOfSeats) : base(id, color, wheels)
        {
            Id = id;
            Color = color;
            Wheels = wheels;
            NumberOfSeats = numberOfSeats;
        }

        public string Id { get; }
        public string Color { get; }
        public int Wheels { get; }
        public int NumberOfSeats { get; }
    }
}