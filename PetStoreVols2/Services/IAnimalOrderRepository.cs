using PetStoreRestAPI3.Models;

namespace PetStoreRestAPI3.Services
{
    public interface IAnimalOrderRepository
    {
        AnimalOrder Create(AnimalOrder newAnimalOrder);
        AnimalOrder Read(int id);
        ICollection<AnimalOrder> ReadAll();
        void Delete(int id);
        void Update(int oldId, AnimalOrder animalOrder);
    }
}
