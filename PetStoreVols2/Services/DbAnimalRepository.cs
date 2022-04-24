using PetStoreRestAPI3.Models;

namespace PetStoreRestAPI3.Services
{
    public class DbAnimalRepository : IAnimalRepository
    {
        private AnimalDbContext _db;
        public DbAnimalRepository(AnimalDbContext db)
        {
            _db = db;
        }
        public Animal Create(Animal newAnimal)
        {
            _db.Animal.Add(newAnimal);
            _db.SaveChanges();
            return newAnimal;
        }
        public void Delete(int id)
        {
            Animal? animalToDelete = Read(id);
            if (animalToDelete != null)
            {
                _db.Animal.Remove(animalToDelete);
                _db.SaveChanges();
            }
        }
        public Animal? Read(int id)
        {
            return _db.Animal.Find(id);
        }
        public ICollection<Animal> ReadAll()
        {
            return _db.Animal.ToList();
        }
        public void Update(int oldId, Animal animal)
        {
            Animal? animalToUpdate = Read(oldId);
            if (animalToUpdate != null)
            {
                animalToUpdate.Dateborn = animal.Dateborn;
                animalToUpdate.Breed = animal.Breed;
                animalToUpdate.Name = animal.Name;
                animalToUpdate.Category= animal.Category;
                animalToUpdate.Gender = animal.Gender;
                animalToUpdate.Registered = animal.Registered;
                animalToUpdate.Color = animal.Color;
                animalToUpdate.Listprice= animal.Listprice;
                animalToUpdate.Photo = animal.Photo;
                animalToUpdate.Imagefile = animal.Imagefile;
                animalToUpdate.Imageheight = animal.Imageheight;
                animalToUpdate.Imagewidth = animal.Imagewidth;
                _db.SaveChanges();
            }
        }
    }
}
