namespace Domain.Migrations
{
    using Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Domain.Concrete.SportStoreContextDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Domain.Concrete.SportStoreContextDB context)
        {
            //  This method will be called after migrating to the latest version.
            
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var products = new List<Product>
            {
                new Product { Name = "Pilka", Category = "Sport", Price = 123.32M },
                new Product { Name = "Rower", Category = "Sport", Price = 4123.32M },
                new Product { Name = "Hantle", Category = "Fitness", Price = 4123.32M }
            };
            //            products.ForEach(p => context.Products.AddOrUpdate(p));
            products.ForEach(product => context.Products.AddOrUpdate(p => p.Name, product));
            context.SaveChanges();
        }
    }
}
