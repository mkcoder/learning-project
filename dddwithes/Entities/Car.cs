using System;
using System.ComponentModel.DataAnnotations;
using learning.DomainObjects;
using Newtonsoft.Json.Linq;

namespace learning.Entity
{
    public class Car
    {
        [Key]
        public Guid Id { get; set; }
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
