using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class City
    {
        [Key]
        public int Cityid { get; set; }
        public int? Zipcode { get; set; }
        public string? City1 { get; set; }
        public string? State { get; set; }
        public int? Areacode { get; set; }
        public int? Population1990 { get; set; }
        public int? Population1980 { get; set; }
        public string? Country { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
