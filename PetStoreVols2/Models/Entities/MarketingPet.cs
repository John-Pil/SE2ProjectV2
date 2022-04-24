
namespace PetStoreRestAPI3.Models
{
    public class MarketingPet
    {
        public int petId;

        public int petType;

        public MarketingPet(int id, int type) 
        {
            petId = id;
            petType = type;
        }
    }
}
