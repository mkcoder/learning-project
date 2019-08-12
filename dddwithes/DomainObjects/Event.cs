using System;
using Newtonsoft.Json.Linq;

namespace learning.DomainObjects
{
    public abstract class Event
    {
        public Guid AggreagteId { get; set; }
        public virtual int Version { get => 1; }
        public abstract string EventName { get; }
    }
}
