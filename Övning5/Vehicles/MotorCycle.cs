namespace Övning5
{
    internal class MotorCycle : Vehicle
    {
        public MotorCycle(string id, string color, int wheels, float lenght) : base(id, color, wheels)
        {
            Id = id;
            Color = color;
            Wheels = wheels;
            Lenght = lenght;
        }

        public string Id { get; }
        public string Color { get; }
        public int Wheels { get; }
        public float Lenght { get; }
    }
}