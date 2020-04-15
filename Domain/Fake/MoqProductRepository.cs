using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

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
        private IEnumerable<Product> CreateFakeRepoImplementation()
        {
            return new List<Product>{
            new Product {Name = "Kajak", Category = "Sporty wodne", Price = 275M},
            new Product {Name = "Kamizelka ratunkowa", Category = "Sporty wodne", Price = 48.95M},
            new Product {Name = "Piłka nożna", Category = "Piłka nożna", Price = 19.50M},
            new Product {Name = "rakieta", Category = "Sport halowy", Price = 31.95M},
            new Product {Name = "Flaga narożna", Category = "Piłka nożna", Price = 34.95M}
            };

            //Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();

            //productRepositoryMock.Setup(m => m.Products).Returns(products);
            //return productRepositoryMock.Object;
        }

        Product IProductRepository.Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
