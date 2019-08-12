using System;
using learning.DomainObjects;
using Newtonsoft.Json.Linq;

namespace learning.Events
{
    public class CreateCar : Event
    {
        public override int Version { get => 1; }
        public override string EventName { get => "CarCreated"; }
        public string CarDoorsWheelType { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string WheelType { get; set; }
        public string VehicleType { get; set; }
        public string Color { get; set; }
        public int CarDoors { get; set; }
        public bool Sunroof { get; set; }
        public string WindowType { get; set; }
    }
}
