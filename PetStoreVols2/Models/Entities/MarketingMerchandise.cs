namespace PetStoreRestAPI3.Models
{
    public class MarketingMerchandise
    {
        public int MerchandiseId;

        public string MerchandiseName;

        public MarketingMerchandise(int id, string name) 
        {
            MerchandiseId = id;
            MerchandiseName = name;
        }
    }
}
