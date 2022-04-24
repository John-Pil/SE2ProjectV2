using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class Breed
    {
        [Key]
        public string Category { get; set; } = null!;
        public string Breed1 { get; set; } = null!;
    }
}
