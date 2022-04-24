using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class Sale
    {
        [Key]
        public int Saleid { get; set; }
        public string? Saledate { get; set; }
        public int? Employeeid { get; set; }
        public int? Customerid { get; set; }
        public double? Salestax { get; set; }
    }
}
