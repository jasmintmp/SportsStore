using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;


namespace Domain.Fake
{
    public class MoqProductRepository : IProductRepository
    {
        
        public IEnumerable<Product> Products
        {
            get { return CreateFakeRepoImplementation(); }
        }

        /// <summary>
        /// Using Moq library to reproduce a repository interface implementation 
        /// Mocking just one hardcoded property Products. 
        /// Pretending to be DB.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Product> CreateFakeRepoImplementation()
        {
            return new List<Product>{
            new Product {Name = "Covid Mask", Price = 34.95M },
            new Product {Name = "Kajak", Category = "Kanue", Price = 275M},
            new Product {Name = "Kamizelka ratunkowa", Category = "Swiming", Price = 48.95M},
            new Product {Name = "Piłka nożna", Category = "Football", Price = 19.50M},
            new Product {Name = "Rakieta", Category = "Tenis", Price = 31.95M},
            new Product {Name = "Flaga narożna", Category = "Football", Price = 34.95M },
            new Product {Name = "Bramka", Category = "Football", Price = 34.95M}};
        }

            //Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();

            //productRepositoryMock.Setup(m => m.Products).Returns(products);
            //return productRepositoryMock.Object;        

        Product IProductRepository.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
