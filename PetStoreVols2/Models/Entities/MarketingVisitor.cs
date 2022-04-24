namespace PetStoreRestAPI3.Models
{
    public class MarketingVisitor
    {
        public int VisitorId;

        public string VisitorName;

        public MarketingVisitor(int id, string name)
        {
            VisitorId = id;
            VisitorName = name;
        }
    }
}
