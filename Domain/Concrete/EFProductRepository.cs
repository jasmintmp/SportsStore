using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private SportStoreContextDB context = new SportStoreContextDB();

        public IEnumerable<Product> Products
        { 
            get { return context.Products; }
        }
        //IEnumerable<TEntity> GetAll();
        public Product Get(int id) => context.Products.FirstOrDefault(p => p.ProductID == id);
        //void Add(TEntity entity);
        //void Update(TEntity dbEntity, TEntity entity);
        //void Delte(TEntity entity);

    }
}
