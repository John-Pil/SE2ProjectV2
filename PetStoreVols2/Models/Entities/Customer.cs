using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class Customer
    {
        [Key]
        public int Customerid { get; set; }
        public string? Phone { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Address { get; set; }
        public int? Zipcode { get; set; }
        public int Cityid { get; set; }
    }
}
