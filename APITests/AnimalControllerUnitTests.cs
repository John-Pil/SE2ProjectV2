using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PetStoreRestAPI3.Controllers;
using PetStoreRestAPI3.Models;

namespace APITests
{
    public class AnimalControllerTests
    {
        private AnimalController controller = new AnimalController("Add Context Here");
        private Animal animal = new Animal();
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
                var list = controller.Index();

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


                if (controller.Edit(1) == controller.Index())
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
                if (controller.Create(animal) != controller.Index())
                {
                    Assert.Fail();
                }

                if (controller.Delete(animal.Animalid) == controller.Index())
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