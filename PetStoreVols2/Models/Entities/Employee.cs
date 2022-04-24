using System.ComponentModel.DataAnnotations;

namespace PetStoreRestAPI3.Models
{
    public class Employee
    {
        [Key]
        public int Employeeid { get; set; }
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? Zipcode { get; set; }
        public int? Cityid { get; set; }
        public string? Taxpayerid { get; set; }
        public DateTime? Datehired { get; set; }
        public string? Datereleased { get; set; }
        public int? Managerid { get; set; }
        public int? Employeelevel { get; set; }
        public string? Title { get; set; }
    }
}
