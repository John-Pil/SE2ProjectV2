using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class SaleAnimal
    {
        [Key]
        public int Saleid { get; set; }
        public int Animalid { get; set; }
        public double? Saleprice { get; set; }
    }
}
