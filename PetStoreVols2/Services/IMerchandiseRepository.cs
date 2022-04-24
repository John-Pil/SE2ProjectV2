using PetStoreRestAPI3.Models;

namespace PetStoreRestAPI3.Services
{
    public interface IMerchandiseRepository
    {
        Merchandise Create(Merchandise newMerchandise);
        Merchandise Read(int id);
        ICollection<Merchandise> ReadAll();
        void Delete(int id);
        void Update(int oldId, Merchandise merchandise);
    }
}
