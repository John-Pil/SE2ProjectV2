using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PetStoreRestAPI3.Controllers;
using PetStoreRestAPI3.Models;

namespace APITests
{
    public class AnimalOrderItemControllerTests
    {
        private AnimalOrderItemController controller = new AnimalOrderItemController("Add Context Here");
        private AnimalOrderItem item = new AnimalOrderItem();
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
                var list = controller.GetAnimalsOrderItem();
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
                var animalOrder = controller.GetAnimalOrderItem(1);
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
                

                if (controller.PutAnimalOrderItem(1, item).GetType() != result.GetType())
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
                var postResult = controller.PostAnimalOrderItem(item);

                if (!postResult.Equals(item))
                {
                    Assert.Fail();
                }

                NoContentResult result = new NoContentResult();

                if (controller.DeleteAnimalOrderItem(postResult.Id).GetType() != result.GetType()) 
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