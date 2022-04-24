using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class AutoNumber
    {
        [Key]
        public string Tablename { get; set; } = null!;
        public int Keyvalue { get; set; }
        public int Keyincrement { get; set; }
    }
}
