using dddwithes.Entities;
using learning.Entity;
using Microsoft.EntityFrameworkCore;

namespace learning.DbContexts
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<AggregateEvent> AggregateEvents { get; set; }
    }
}
