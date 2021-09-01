using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceSystem.DataParse;
using ECommerceSystem.ProductManaging.Entities;

namespace ECommerceSystem.ProductManaging.Repositories
{
    public interface IProductRepository : IRepository<Product, int>
    {
    }
}
