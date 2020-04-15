using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Abstract
{
    public interface IProductRepository
    {
        //in real will be connected to DB
        IEnumerable<Product> Products { get; }
    //IEnumerable<TEntity> GetAll();
        Product Get(int id);
    //    void Add(TEntity entity);
    //    void Update(TEntity dbEntity, TEntity entity);
    //    void Delte(TEntity entity);
    //
    }
}
