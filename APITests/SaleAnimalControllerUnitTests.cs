using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PetStoreRestAPI3.Controllers;
using PetStoreRestAPI3.Models;

namespace APITests
{
    public class SaleAnimalControllerTests
    {
        private SaleAnimalController controller = new SaleAnimalController("Add Context Here");
        private SaleAnimal animal = new SaleAnimal();
        NoContentResult result = new NoContentResult();
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void GetIdTest()
        {
            try
            {
                var animalOrder = controller.GetSaleAnimal(1);
            }
            catch
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        public void PutTest()
        {
            try
            {
                

                if (controller.PutSaleAnimal(1, animal).GetType() != result.GetType())
                {
                    Assert.Fail();
                }
            }
            catch
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        public void PostDeleteTest()
        {
            try
            {
                var postResult = controller.PostSaleAnimal(animal);

                if (!postResult.Equals(animal))
                {
                    Assert.Fail();
                }

                NoContentResult result = new NoContentResult();

                if (controller.DeleteSaleAnimal(postResult.Id).GetType() != result.GetType()) 
                {
                    Assert.Fail();
                }
            }
            catch
            {
                Assert.Fail();
            }

            Assert.Pass();
        }
    }
}