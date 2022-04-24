using PetStoreRestAPI3.Models;

namespace PetStoreRestAPI3.Services
{
    public class DbAnimalOrderRepository : IAnimalOrderRepository
    {
        private AnimalDbContext _db;
        public DbAnimalOrderRepository(AnimalDbContext db)
        {
            _db = db;
        }
        public AnimalOrder Create(AnimalOrder newAnimalOrder)
        {
            _db.AnimalOrder.Add(newAnimalOrder);
            _db.SaveChanges();
            return newAnimalOrder;
        }
        public void Delete(int id)
        {
            AnimalOrder? animalOrderToDelete = Read(id);
            if (animalOrderToDelete != null)
            {
                _db.AnimalOrder.Remove(animalOrderToDelete);
                _db.SaveChanges();
            }
        }
        public AnimalOrder? Read(int id)
        {
            return _db.AnimalOrder.Find(id);
        }
        public ICollection<AnimalOrder> ReadAll()
        {
            return _db.AnimalOrder.ToList();
        }
        public void Update(int oldId, AnimalOrder animalOrder)
        {
            AnimalOrder? animalOrderToUpdate = Read(oldId);
            if (animalOrderToUpdate != null)
            {
                animalOrderToUpdate.Orderid = animalOrder.Orderid;
                animalOrderToUpdate.Orderdate = animalOrder.Orderdate;
                animalOrderToUpdate.Receivedate = animalOrder.Receivedate;
                animalOrderToUpdate.Supplierid= animalOrder.Supplierid;
                animalOrderToUpdate.Shippingcost = animalOrder.Shippingcost;
                animalOrderToUpdate.Employeeid = animalOrder.Employeeid;
                _db.SaveChanges();
            }
        }
    }
}
