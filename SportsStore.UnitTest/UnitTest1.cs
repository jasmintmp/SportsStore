using NUnit.Framework;
using Moq;
using Domain.Abstract;
using System.Web.Mvc;

namespace SportsStore.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
           
        }

        [Test]
        public void List_ProductList_SutablePage()
        {
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            var productRepository = DependencyResolver.Current.GetService<IProductRepository>();
           //mock.Setup(m => m.Products).Returns
            Assert.Pass();
        }
    }
}