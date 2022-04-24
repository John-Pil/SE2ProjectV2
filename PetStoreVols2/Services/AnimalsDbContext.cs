using Microsoft.EntityFrameworkCore;

namespace PetStoreRestAPI3.Models
{
    public class AnimalDbContext : DbContext
    {
        public DbSet<Animal> Animal { get; set; }
        public DbSet<AnimalOrder> AnimalOrder { get; set; }
        public DbSet<AnimalOrderItem> AnimalOrderItem { get; set; }
        public DbSet<AutoNumber> AutoNumber { get; set; }
        public DbSet<Breed> Breed { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerAccount> CustomerAccount { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Merchandise> Merchandise { get; set; }
        public DbSet<MerchandiseOrder> MerchandiseOrder { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Preference> Preference { get; set; }
        public DbSet<Revision> Revision { get; set; }
        public DbSet<Sale> Sale { get; set; }
        public DbSet<SaleAnimal> SaleAnimal { get; set; }
        public DbSet<SaleItem> SaleItem { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public AnimalDbContext(DbContextOptions<AnimalDbContext> options) : base(options)
        {

        }
        

    }
}
