using learning.DomainObjects;
using MediatR;

namespace learning.Events
{
    public class CarFeaturesChanged : Event, INotification
    {
        public override int Version { get => 1; }
        public override string EventName { get => "CarFeaturesChanged"; }
        public string CarDoorsWheelType { get; set; }
        public string WheelType { get; set; }
        public bool Sunroof { get; set; }
        public string WindowType { get; set; }
    }
}
