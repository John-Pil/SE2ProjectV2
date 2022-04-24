using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PetStoreRestAPI3.Controllers;
using PetStoreRestAPI3.Models;

namespace APITests
{
    public class MerchandiseControllerTests
    {
        private MerchandiseController controller = new MerchandiseController("Add Context Here");
        private Merchandise item = new Merchandise();
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
                if (controller.Create(item) != controller.Index())
                {
                    Assert.Fail();
                }

                if (controller.Delete(item.Itemid) == controller.Index())
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