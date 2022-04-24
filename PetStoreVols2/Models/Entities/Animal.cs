using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
 
    
        public partial class Animal
        {
        [Key]
            public int Animalid { get; set; }
            public string? Name { get; set; }
            public string? Category { get; set; }
            public string? Breed { get; set; }
            public DateTime? Dateborn { get; set; }
            public string? Gender { get; set; }
            public string? Registered { get; set; }
            public string? Color { get; set; }
            public double? Listprice { get; set; }
            public string? Photo { get; set; }
            public string? Imagefile { get; set; }
            public string? Imageheight { get; set; }
            public string? Imagewidth { get; set; }
        }
    
}
