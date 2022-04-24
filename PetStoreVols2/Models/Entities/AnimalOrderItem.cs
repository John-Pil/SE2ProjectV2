using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class AnimalOrderItem
    {
        [Key]
        public int Orderid { get; set; }
        public int Animalid { get; set; }
        public double? Cost { get; set; }
    }
}
