using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using Moq;
using System.Collections.Generic;
using System.Linq;
//using System.Web.WebPages.Html;
using SportsStore.WebUI.Models;
using System.Web.Mvc;
using SportsStore.WebUI.HtmlHelpers;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                                            new Product {ProductID = 1, Name = "P1"},
                                            new Product {ProductID = 2, Name = "P2"},
                                            new Product {ProductID = 3, Name = "P3"},
                                            new Product {ProductID = 4, Name = "P4"},
                                            new Product {ProductID = 5, Name = "P5"}
                                            });
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //Act
            IEnumerable<Product> result = (IEnumerable<Product>)controller.List(null, 2).Model;

            //Assert
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }
        [TestMethod]
        public void Can_Generate_Page_Links()
        {
            // Arrange - define an HTML helper - we need to do this
            // in order to apply the extension method
            HtmlHelper myHelper = null;
            // Arrange - create PagingInfo data
            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };

            //Arrange - set up the delegate using a lambda expression
            Func<int, string> pageUrlDelegate = i => "Page" + i;

            //Act
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);

            //Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>" + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>" + @"<a class=""btn btn-default"" href=""Page3"">3</a>", result.ToString());
        }
        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                                                        new Product {ProductID = 1, Name = "P1"},
                                                        new Product {ProductID = 2, Name = "P2"},
                                                        new Product {ProductID = 3, Name = "P3"},
                                                        new Product {ProductID = 4, Name = "P4"},
                                                        new Product {ProductID = 5, Name = "P5"}
                                                        });
            // Arrange
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // Act
            ProductsListViewModel result = (ProductsListViewModel)controller.List(null, 2).Model;
            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPages, 2);
        }
        [TestMethod]
        public void Can_Filter_Products()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                new Product[] { 
                                new Product {ProductID = 1, Name = "P1", Category = "Cat1"},
                                new Product {ProductID = 2, Name = "P2", Category = "Cat2"},
                                new Product {ProductID = 3, Name = "P3", Category = "Cat1"},
                                new Product {ProductID = 4, Name = "P4", Category = "Cat2"},
                                new Product {ProductID = 5, Name = "P5", Category = "Cat3"}
                              });

            //Arrange - create a controller  and make the page size 3 times

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            //Action

            ProductsListViewModel model = (ProductsListViewModel)controller.List("Cat2", 1).Model;
            Product[] result = model.Products.ToArray();
            Assert.AreEqual(result.Length, 2);
            Assert.IsTrue(result[0].Name == "P2" && result[0].Category == "Cat2");
            Assert.IsTrue(result[1].Name == "P4" && result[0].Category == "Cat2");

        }
        [TestMethod]
        public void Can_Create_Categories()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                new Product[] {
                                new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                                new Product {ProductID = 2, Name = "P2", Category = "Apples"},
                                new Product {ProductID = 3, Name = "P3", Category = "Plums"},
                                new Product {ProductID = 4, Name = "P4", Category = "Oranges"}                
                });

            NavController controller = new NavController(mock.Object);
            string[] result = ((IEnumerable<string>)controller.Menu().Model).ToArray();

            Assert.AreEqual(result.Length,3);
            Assert.IsTrue(result[0] == "Apples");
            Assert.AreEqual(result[1], "Oranges");
            Assert.AreEqual(result[2], "Plums");
        }
        [TestMethod]
        public void Indicate_Selected_Category()
        {
            //Arrange
            //- Create the mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                new Product[] {
                                 new Product {ProductID = 1, Name = "P1", Category = "Apples"},
                                 new Product {ProductID = 4, Name = "P2", Category = "Oranges"},                
                });

            NavController controller = new NavController(mock.Object);

            string categoryToSelect = "Apples";
            

            //Act

            string result = controller.Menu(categoryToSelect).ViewBag.SelectedCategory;
            //Assert

            Assert.AreEqual(categoryToSelect, result);
        }
        [TestMethod]
        public void Generate_Category_Specific_Product_Count()
        {
            //Arrange
            //Create the mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(
                new Product[] {
                                new Product {ProductID = 1, Name = "P1", Category = "Cat1"},
                                new Product {ProductID = 2, Name = "P2", Category = "Cat2"},
                                new Product {ProductID = 3, Name = "P3", Category = "Cat1"},
                                new Product {ProductID = 4, Name = "P4", Category = "Cat2"},
                                new Product {ProductID = 5, Name = "P5", Category = "Cat3"}                
                });

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            //Act

            int res1 = ((ProductsListViewModel)controller.List("Cat1").Model).PagingInfo.TotalItems;
            int res2 = ((ProductsListViewModel)controller.List("Cat2").Model).PagingInfo.TotalItems;
            int res3 = ((ProductsListViewModel)controller.List("Cat3").Model).PagingInfo.TotalItems;
            int res4 = ((ProductsListViewModel)controller.List(null).Model).PagingInfo.TotalItems;
            //Assert

            Assert.AreEqual(res1,2);
            Assert.AreEqual(res2,2);
            Assert.AreEqual(res3,1);
            Assert.AreEqual(res4,5);

        }
    }
}
