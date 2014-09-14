using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;
using Moq;
using SportsStore.Domain.Abstract;
using System.Linq;
using SportsStore.WebUI.Controllers;
using System.Web.Mvc;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class ImageTests
    {
        [TestMethod]
        public void Can_Retreive_Image_Data()
        {
            //Arrange - create a product with image data
            Product prod = new Product
            {
                ProductID = 2,
                Name = "test",
                ImageData = new Byte[] { },
                ImageMimeType = "image/png"

            };

            //Arrange -create a mock repository

            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.Products).Returns(new Product[] { 
                new Product{ProductID=1,Name="P1"},
                prod,
                new Product{ProductID=3,Name="P3"}           
            
            }.AsQueryable());

            ProductController controller = new ProductController(mock.Object);

            ActionResult result = controller.GetImage(2);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(FileResult));
            Assert.AreEqual(prod.ImageMimeType, ((FileResult)result).ContentType);

        }
        [TestMethod]
        public void Cannot_Retrieve_Image_Data_For_Invalid_Id()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] { 
            new Product{ProductID=1,Name="P1"},
            new Product{ProductID=2,Name="P2"}            
            }.AsQueryable());

            //Arrange -create the controller

            ProductController controller = new ProductController(mock.Object);

            //Act - call the getimage action method

            ActionResult result = controller.GetImage(100);

            Assert.IsNull(result);

        }
    }
}
