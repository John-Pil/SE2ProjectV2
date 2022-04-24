using PetStoreRestAPI3.Models;

namespace PetStoreRestAPI3.Services
{
    public class DbMerchandiseRepository : IMerchandiseRepository
    {
        private AnimalDbContext _db;
        public DbMerchandiseRepository(AnimalDbContext db)
        {
            _db = db;
        }
        public Merchandise Create(Merchandise newMerchandise)
        {
            _db.Merchandise.Add(newMerchandise);
            _db.SaveChanges();
            return newMerchandise;
        }
        public void Delete(int id)
        {
            Merchandise? merchandiseToDelete = Read(id);
            if (merchandiseToDelete != null)
            {
                _db.Merchandise.Remove(merchandiseToDelete);
                _db.SaveChanges();
            }
        }
        public Merchandise? Read(int id)
        {
            return _db.Merchandise.Find(id);
        }
        public ICollection<Merchandise> ReadAll()
        {
            return _db.Merchandise.ToList();
        }
        public void Update(int oldId, Merchandise merchandise)
        {
            Merchandise? merchandiseToUpdate = Read(oldId);
            if (merchandiseToUpdate != null)
            {
                merchandiseToUpdate.Description = merchandise.Description;
                merchandiseToUpdate.Quantityonhand = merchandise.Quantityonhand;
                merchandiseToUpdate.Listprice= merchandise.Listprice;
                merchandiseToUpdate.Category = merchandise.Category;

                _db.SaveChanges();
            }
        }
    }
}
