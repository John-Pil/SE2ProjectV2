using PetStoreRestAPI3.Models;

namespace PetStoreRestAPI3
{
    public class MonitoringPost
    { 
        public async void runRoutine() 
        {
            using (var client = new HttpClient()) 
            {
                //populate lists of objects to send
                List<MarketingPet> petPosts = new List<MarketingPet>(petConversion());
                List<MarketingMerchandise> merchPosts = new List<MarketingMerchandise>(merchConversion());
                List<MarketingTransaction> transactionPosts = new List<MarketingTransaction>(transactionConversion());
                List<MarketingVisitor> visitorPosts = new List<MarketingVisitor>(visitorConversion());
                List<MarketingSession> sessionPosts = new List<MarketingSession>(sessionConversion());
                
                //send all data to Marketing Team
                foreach (MarketingPet pet in petPosts)
                {
                    await client.PostAsJsonAsync("https://monitoringapplicati0n.azurewebsites.net/api/create/pet", pet);
                }
                
                foreach (MarketingMerchandise merch in merchPosts)
                {
                    await client.PostAsJsonAsync("https://monitoringapplicati0n.azurewebsites.net/api/create/merchandise", merch);
                }
                
                foreach (MarketingTransaction transaction in transactionPosts)
                {
                    await client.PostAsJsonAsync("https://monitoringapplicati0n.azurewebsites.net/api/create/transaction", transaction);
                }
                
                foreach (MarketingVisitor visitor in visitorPosts)
                {
                    await client.PostAsJsonAsync("https://monitoringapplicati0n.azurewebsites.net/api/create/visitor", visitor);
                }

                foreach (MarketingSession session in sessionPosts) 
                {
                    await client.PostAsJsonAsync("https://monitoringapplicati0n.azurewebsites.net/api/create/session", session);
                }
            }
        }

        private List<MarketingPet> petConversion() 
        {
            List<MarketingPet> ret = new List<MarketingPet>();
            List<Animal> animals = new List<Animal>();

            return ret;
        }

        private List<MarketingMerchandise> merchConversion()
        {
            List<MarketingMerchandise> ret = new List<MarketingMerchandise>();
            List<Merchandise> merchandise = new List<Merchandise>();

            return ret;
        }

        private List<MarketingTransaction> transactionConversion()
        {
            List<MarketingTransaction> ret = new List<MarketingTransaction>();
            List<SaleAnimal> animalSales;
            List<SaleItem> itemSales;

            return ret;
        }

        private List<MarketingVisitor> visitorConversion()
        {
            List<MarketingVisitor> ret = new List<MarketingVisitor>();
            List<Customer> customers;

            return ret;
        }

        private List<MarketingSession> sessionConversion() 
        {
            List<MarketingSession> ret = new List<MarketingSession>();

            return ret;
        }
    }
}
