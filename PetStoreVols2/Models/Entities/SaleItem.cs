using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class SaleItem
    {
        [Key]
        public int Saleid { get; set; }
     
        public int Itemid { get; set; }
        public int? Quantity { get; set; }
        public double? Saleprice { get; set; }
    }
}
