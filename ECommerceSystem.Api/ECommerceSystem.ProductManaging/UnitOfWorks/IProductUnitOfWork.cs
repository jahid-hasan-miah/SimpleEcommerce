using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceSystem.DataParse;
using ECommerceSystem.ProductManaging.Repositories;

namespace ECommerceSystem.ProductManaging.UnitOfWorks
{
    public interface IProductUnitOfWork : IUnitOfWork
    {
        IProductRepository Products { get; }
    }
}
