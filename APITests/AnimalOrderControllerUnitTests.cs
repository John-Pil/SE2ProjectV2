using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PetStoreRestAPI3.Controllers;
using PetStoreRestAPI3.Models;

namespace APITests
{
    public class AnimalOrderControllerTests
    {
        private AnimalOrderController controller = new AnimalOrderController("Add Context Here");
        private AnimalOrder order = new AnimalOrder();
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
                if (controller.Create(order) != controller.Index())
                {
                    Assert.Fail();
                }

                if (controller.Delete(order.Orderid) == controller.Index())
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