using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PetStoreRestAPI3.Controllers;
using PetStoreRestAPI3.Models;

namespace APITests
{
    public class BreedControllerTests
    {
        private BreedController controller = new BreedController("Add Context Here");
        private Breed breed = new Breed();
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
                var list = controller.GetBreed();
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
                var animalOrder = controller.GetBreed(1);
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
                

                if (controller.PutBreed("1", breed).GetType() != result.GetType())
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
                var postResult = controller.PostBreed(breed);

                if (!postResult.Equals(breed))
                {
                    Assert.Fail();
                }

                NoContentResult result = new NoContentResult();

                if (controller.DeleteBreed(postResult.Id).GetType() != result.GetType()) 
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