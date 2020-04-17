using NUnit.Framework;
using Domain.Abstract;
using System.Web.Mvc;
using WebUI.Controllers;
using System.Collections.Generic;
using Domain.Entities;
using Moq;
using Domain.Fake;
using System.Linq;
using WebUI.Models;
using WebUI.HtmlHelpers;
using Microsoft.CSharp;

namespace SportsStore.UnitTest
{
    [TestFixture]
    public class UnitTest1
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void List_ProductList_SutablePage()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            });

            var sut = new ProductController(mock.Object);
            sut.PageSize = 2;
            //Action method returns ViewResult.Model 
            WebUI.Models.ProductListViewModel result = (ProductListViewModel)sut.List(null,1).Model;
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name,"P1");
            Assert.AreEqual(prodArray[1].Name,"P2");


        }

        [Test]
        public void Can_Generate_Page_Links()
        {
            HtmlHelper htmlHelper = null;

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItemsInCategory = 28,
                ItemsPerPage = 10
            };

            var result = htmlHelper.PageLinks(pagingInfo, i => "Strona" + i);
            
            // aserts
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Strona1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Strona2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Strona3"">3</a>",
                result.ToString());
        }

        [Test]
        public void Can_Send_Pagination_View_Model()
        {

            // przygotowanie
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1"},
                new Product {ProductID = 2, Name = "P2"},
                new Product {ProductID = 3, Name = "P3"},
                new Product {ProductID = 4, Name = "P4"},
                new Product {ProductID = 5, Name = "P5"}
            });

            // przygotowanie
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            // działanie strona 2
            ProductListViewModel result = (ProductListViewModel)controller.List(null, 2).Model;

            // asercje
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItemsInCategory, 5);
            Assert.AreEqual(pageInfo.TotalItemsInCategory, 2);
        }

        [Test]
        public void Can_Filter_Products()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Football"},
                new Product {ProductID = 2, Name = "P2", Category = "PingPong"},
                new Product {ProductID = 3, Name = "P3", Category = "Football"},
                new Product {ProductID = 4, Name = "P4", Category = "PingPong"},
                new Product {ProductID = 5, Name = "P5", Category = "PingPong"}
            });

            var sut = new ProductController(mock.Object);
            sut.PageSize = 4;
            //Action method returns ViewResult.Model 
            WebUI.Models.ProductListViewModel result = (ProductListViewModel)sut.List("Football", 1).Model;
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.IsTrue(prodArray[0].Name == "P1" && prodArray[0].Category == "Football");
            Assert.IsTrue(prodArray[1].Name == "P3" && prodArray[0].Category == "Football");


        }
        [Test]
        public void Can_Create_Category()
        {
            //
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Football"},
                new Product {ProductID = 2, Name = "P2", Category = "PingPong"},
                new Product {ProductID = 3, Name = "P3", Category = "Football"},
                new Product {ProductID = 4, Name = "P4", Category = "PingPong"},
                new Product {ProductID = 5, Name = "P5", Category = "PingPong"}
            });

            var sut = new NavController(mock.Object);

            //
            string[] result = ((IEnumerable<string>)sut.Menu().Model).ToArray();

            //
            Assert.IsTrue(result.Length == 2);
            Assert.IsTrue(result[0] == "Football");
            Assert.IsTrue(result[1] == "PingPong");


        }

        [Test]
        public void Indicates_Selected_Category()
        {
            //
            Mock<IProductRepository> mock = new Mock<IProductRepository>();

            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Football"},
                new Product {ProductID = 2, Name = "P2", Category = "PingPong"},
                new Product {ProductID = 3, Name = "P3", Category = "Football"},
                new Product {ProductID = 4, Name = "P4", Category = "PingPong"},
                new Product {ProductID = 5, Name = "P5", Category = "PingPong"}
            });

            var sut = new NavController(mock.Object);

            //
            string selectedCategory = "PingPong";

            var result = sut.Menu(selectedCategory).ViewBag.SelectedCategory;

            //
            Assert.AreEqual(result, "PingPong");


        }

        [Test]
        public void Generate_Category_Specific_Product_Count()
        {
            // przygotowanie
            // - utworzenie imitacji repozytorium
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[] {
                new Product {ProductID = 1, Name = "P1", Category = "Cat1"},
                new Product {ProductID = 2, Name = "P2", Category = "Cat2"},
                new Product {ProductID = 3, Name = "P3", Category = "Cat1"},
                new Product {ProductID = 4, Name = "P4", Category = "Cat2"},
                new Product {ProductID = 5, Name = "P5", Category = "Cat3"},
                new Product {ProductID = 5, Name = "P6"},
                new Product {ProductID = 5, Name = "P7"}
            });

            // przygotowanie - utworzenie kontrolera i ustawienie 3-elementowej strony
            var sut = new ProductController(mock.Object);
            sut.PageSize = 3;

            // działanie - testowanie liczby produktów dla różnych kategorii
            int res1 = ((ProductListViewModel)sut
                .List("Cat1").Model).PagingInfo.TotalItemsInCategory;
            int res2 = ((ProductListViewModel)sut
                .List("Cat2").Model).PagingInfo.TotalItemsInCategory;
            int res3 = ((ProductListViewModel)sut
                .List("Cat3").Model).PagingInfo.TotalItemsInCategory;
            int noCat = ((ProductListViewModel)sut
                .List(null).Model).PagingInfo.TotalItemsInCategory;

            // asercje
            Assert.AreEqual(res1, 2);
            Assert.AreEqual(res2, 2);
            Assert.AreEqual(res3, 1);
            Assert.AreEqual(noCat, 2);
        }
    }
}