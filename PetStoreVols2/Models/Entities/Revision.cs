using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class Revision
    {
        [Key]
        public int Revisionid { get; set; }
        public double? Version { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public DateTime? Releasedate { get; set; }
    }
}
