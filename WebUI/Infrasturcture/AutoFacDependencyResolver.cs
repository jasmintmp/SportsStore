using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Moq;
using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;

namespace WebUI.Infrastructure
{
    public class AutoFacDependencyResolver
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            // You can register controllers all at once using assembly scanning...
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
            // ...or you can register individual type controlllers manually.
            //builder.RegisterType<HomeController>().InstancePerRequest();

            // register one instance
            builder.RegisterInstance(CreateFakeRepoImplementation()).As<IProductRepository>().SingleInstance();

            // Set the dependency resolver to be Autofac
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
        /// <summary>
        /// Using Moq library to reproduce a repository interface implementation 
        /// Mocking just one hardcoded property Products. 
        /// Pretending to be DB.
        /// </summary>
        /// <returns></returns>
        private static IProductRepository CreateFakeRepoImplementation()
        {
            List<Product> products = new List<Product>{
            new Product {Name = "Kajak", Category = "Sporty wodne", Price = 275M},
            new Product {Name = "Kamizelka ratunkowa", Category = "Sporty wodne", Price = 48.95M},
            new Product {Name = "Piłka nożna", Category = "Piłka nożna", Price = 19.50M},
            new Product {Name = "Flaga narożna", Category = "Piłka nożna", Price = 34.95M}
        };

            Mock<IProductRepository> productRepositoryMock = new Mock<IProductRepository>();
            productRepositoryMock.Setup(m => m.Products).Returns(products);
            return productRepositoryMock.Object;
        }
    }
}