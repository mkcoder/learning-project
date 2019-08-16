using System;
using System.ComponentModel.DataAnnotations;
using learning.DomainObjects;
using MediatR;
using Newtonsoft.Json.Linq;

namespace dddwithes.Entities
{
    public class AggregateEvent : INotification
    {
        [Key]
        public int Id { get; set; }
        public Guid EventId { get; set; }
        public DateTime Created { get; set; }
        public string EventName { get; set; }
        public Guid AggregateId { get; set; }
        public string Data { get; set; }
        public string RequestData { get; set; }
        public string Request { get; set; }

        internal static AggregateEvent Create<T>(Guid aggregateId, Event e, object requestData)
        {
            return new AggregateEvent
            {
                EventId = e.EventId,
                Created = DateTime.UtcNow,
                AggregateId = aggregateId,
                EventName = e.EventName,
                Data = JObject.FromObject(e).ToString(),
                Request = typeof(T).FullName.ToString(),
                RequestData = JObject.FromObject(requestData).ToString()
            };
        }
    }
}
