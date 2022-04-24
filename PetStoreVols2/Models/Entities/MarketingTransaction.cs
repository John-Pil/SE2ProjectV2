namespace PetStoreRestAPI3.Models
{
    public class MarketingTransaction
    {
        public int TransactionId;

        public List<MarketingPet> Pets;

        public List<MarketingMerchandise> Merchandises;

        public MarketingTransaction(int id, List<MarketingPet> pets, List<MarketingMerchandise> merch) 
        {
            TransactionId = id;
            Pets = pets;
            Merchandises = merch;
        }
    }
}
