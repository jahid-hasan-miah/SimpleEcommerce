using ECommerceSystem.ProductManaging.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.ProductManaging.Services
{
    public interface IProductService
    {
        BusinessObjects.Product GetProduct(int id);
        IList<Product> GetProduct();
        public void AddNewProduct(BusinessObjects.Product product);
        public void UpdateProduct(BusinessObjects.Product product);
        public void DeleteProduct(int id);
        IList<Product> GetFlaggedProduct();
        Product GetFlaggedProduct(int id);
    }
}
