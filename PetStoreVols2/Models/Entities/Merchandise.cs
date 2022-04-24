using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class Merchandise
    {
        [Key]
        public int Itemid { get; set; }
        public string? Description { get; set; }
        public int? Quantityonhand { get; set; }
        public double? Listprice { get; set; }
        public string? Category { get; set; }
    }
}
