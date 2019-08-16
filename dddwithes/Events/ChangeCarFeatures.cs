using System;
using learning.Entity;
using MediatR;
using Newtonsoft.Json.Linq;

namespace learning.Events
{
    public class ChangeCarFeatures : IRequest<CarFeaturesChanged>
    {
        public Guid AggregateId { get; set; }
        public string CarDoorsWheelType { get; set; }
        public string WheelType { get; set; }
        public bool Sunroof { get; set; }
        public string WindowType { get; set; }
    }
}
