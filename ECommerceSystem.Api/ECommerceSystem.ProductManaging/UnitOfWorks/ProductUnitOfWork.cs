using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceSystem.ProductManaging.Contexts;
using ECommerceSystem.DataParse;
using ECommerceSystem.ProductManaging.Repositories;
using ECommerceSystem.ProductManaging.UnitOfWorks;

namespace ECommerceSystem.ProductManaging.UnitOfWorks
{
    public class ProductUnitOfWork : UnitOfWork, IProductUnitOfWork
    {
        public IProductRepository Products { get; private set; }
        public ProductUnitOfWork(IProductContext productContext,
            IProductRepository product) : base((DbContext)productContext)
        {
            Products = product;
        }
    }
}
