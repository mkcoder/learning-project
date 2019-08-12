using System;
namespace learning.Aggregates
{
    public abstract class AggregateRoot
    {
        public abstract Guid Aggregate { get; }
    }
}
