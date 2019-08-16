using System;
using System.ComponentModel.DataAnnotations;

namespace dddwithes.Entities
{
    public class Inventory
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public int Quantity { get; set; }
        public int Lot { get; set; }
    }
}
