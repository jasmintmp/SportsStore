using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using Domain.Concrete;
using Domain.Fake;

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
            //builder.RegisterInstance(CreateFakeRepoImplementation()).As<IProductRepository>().SingleInstance();

            //FAKE repo
            //builder.RegisterType<MoqProductRepository>().As<IProductRepository>().SingleInstance();

            //EF repo
            builder.RegisterType<EFProductRepository>().As<IProductRepository>().SingleInstance();

            // Set the dependency resolver to be Autofac
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //manually resolve
            //var calc2 = DependencyResolver.Current.GetService<IValueCalculator>();

        }

    }
}