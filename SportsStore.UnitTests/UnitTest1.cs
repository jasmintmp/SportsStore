using NUnit.Framework;
using Domain.Abstract;
using System.Web.Mvc;
using WebUI.Controllers;
using System.Collections.Generic;
using Domain.Entities;
using Moq;
using Domain.Fake;
using System.Linq;

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
            var result = (IEnumerable<Product>)sut.List(1).Model;
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name,"P1");
            Assert.AreEqual(prodArray[1].Name,"P2");


        }
    }
}