using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class AnimalOrder
    {
        [Key]
        public int Orderid { get; set; }
        public DateTime? Orderdate { get; set; }
        public DateTime? Receivedate { get; set; }
        public int? Supplierid { get; set; }
        public double? Shippingcost { get; set; }
        public int? Employeeid { get; set; }
        
    }
}
