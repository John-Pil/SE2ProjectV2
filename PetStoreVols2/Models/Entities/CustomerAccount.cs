using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class CustomerAccount
    {
        [Key]
        public int Accountid { get; set; }
        public int? Customerid { get; set; }
        public int? Balance { get; set; }
    }
}
