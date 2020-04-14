using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Abstract
{
    public interface IProductRepository
    {
        //in real will be connected to DB
        IEnumerable<Product> Products { get; } 
    }
}
