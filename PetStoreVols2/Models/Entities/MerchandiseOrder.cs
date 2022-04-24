using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class MerchandiseOrder
    {
        [Key]
        public int Ponumber { get; set; }
        public DateTime? Orderdate { get; set; }
        public DateTime? Receivedate { get; set; }
        public int? Supplierid { get; set; }
        public int? Employeeid { get; set; }
        public double? Shippingcost { get; set; }
    }
}
