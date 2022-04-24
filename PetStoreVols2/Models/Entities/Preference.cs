using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class Preference
    {
        [Key]
        public string Keyid { get; set; }
        public int? Value { get; set; }
        public string? Description { get; set; }
    }
}
