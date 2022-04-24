using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class Category
    {
        [Key]
        public string Category1 { get; set; } = null!;
        public string? Registration { get; set; }
    }
}
