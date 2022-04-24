using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class OrderItem
    {
        [Key]
        public int Ponumber { get; set; }
        public int Itemid { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
    }
}
