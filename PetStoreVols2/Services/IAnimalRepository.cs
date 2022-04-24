using PetStoreRestAPI3.Models;

namespace PetStoreRestAPI3.Services
{
    public interface IAnimalRepository
    {
        Animal Create(Animal newAnimal);
        Animal Read(int id);
        ICollection<Animal> ReadAll();
        void Delete(int id);
        void Update(int oldId, Animal animal);
    }
}
