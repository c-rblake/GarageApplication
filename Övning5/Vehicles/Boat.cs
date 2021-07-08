namespace Övning5
{
    internal class Boat : Vehicle
    {
        public Boat(string id, string color, int wheels, float cylinderVolume) : base(id, color, wheels)
        {
            Id = id;
            Color = color;
            Wheels = wheels;
            CylinderVolume = cylinderVolume;
        }

        public string Id { get; }
        public string Color { get; }
        public int Wheels { get; }
        public float CylinderVolume { get; }
    }
}