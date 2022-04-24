using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PetStoreRestAPI3.Controllers;
using PetStoreRestAPI3.Models;

namespace APITests
{
    public class CityControllerTests
    {
        private CityController controller = new AnimalOrderItemController("Add Context Here");
        private City city = new City();
        NoContentResult result = new NoContentResult();
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void GetTest()
        {
            try
            {
                var list = controller.GetCity();
            }
            catch 
            {
                Assert.Fail();
            }

            Assert.Pass();
        }

        [Test]
        public void GetIdTest()
        {
            try
            {
                var animalOrder = controller.GetCity(1);
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
                

                if (controller.PutCity(1, city).GetType() != result.GetType())
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
                var postResult = controller.PostCity(city);

                if (!postResult.Equals(city))
                {
                    Assert.Fail();
                }

                NoContentResult result = new NoContentResult();

                if (controller.DeleteCity(postResult.Id).GetType() != result.GetType()) 
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