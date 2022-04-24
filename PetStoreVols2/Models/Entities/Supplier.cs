using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class Supplier
    {
        [Key]
        public int Supplierid { get; set; }
        public string? Name { get; set; }
        public string? Contactname { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? Zipcode { get; set; }
        public int? Cityid { get; set; }

    }
}
