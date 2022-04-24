using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PetStoreRestAPI3.Controllers;
using PetStoreRestAPI3.Models;

namespace APITests
{
    public class MerchandiseOrderControllerTests
    {
        private MerchandiseOrderController controller = new MerchandiseOrderController("Add Context Here");
        private MerchandiseOrder order = new MerchandiseOrder();
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
                var list = controller.GetMerchandiseOrder();
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
                var animalOrder = controller.GetMerchandiseOrder(1);
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
                

                if (controller.PutMerchandiseOrder(1, order).GetType() != result.GetType())
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
                var postResult = controller.PostMerchandiseOrder(order);

                if (!postResult.Equals(order))
                {
                    Assert.Fail();
                }

                NoContentResult result = new NoContentResult();

                if (controller.DeleteMerchandiseOrder(postResult.Id).GetType() != result.GetType()) 
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