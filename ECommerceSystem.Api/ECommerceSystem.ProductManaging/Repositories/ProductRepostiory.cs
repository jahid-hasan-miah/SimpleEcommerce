using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceSystem.DataParse;
using ECommerceSystem.ProductManaging.Contexts;
using ECommerceSystem.ProductManaging.Entities;

namespace ECommerceSystem.ProductManaging.Repositories
{
    public class ProductRepostiory : Repository<Product, int>, IProductRepository
    {
        public ProductRepostiory(IProductContext context) : base((DbContext)context)
        {
        }
    }
}
