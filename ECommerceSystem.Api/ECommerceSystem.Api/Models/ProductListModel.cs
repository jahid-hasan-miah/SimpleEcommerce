using Autofac;
using ECommerceSystem.Api;
using ECommerceSystem.Api.Models;
using ECommerceSystem.ProductManaging.BusinessObjects;
using ECommerceSystem.ProductManaging.Services;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceSystem.Api.Models
{
    public class ProductListModel
    {
        private readonly IProductService _productService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductListModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
            _httpContextAccessor = Startup.AutofacContainer.Resolve<IHttpContextAccessor>();
        }
        public ProductListModel(IProductService productService, IHttpContextAccessor httpContextAccessor)
        {
            _productService = productService;
            _httpContextAccessor = httpContextAccessor;
        }
        public IList<Product> Get()
        {
            var product = _productService.GetProduct();
            return product;
        }
        public IList<Product> GetTrash()
        {
            var product = _productService.GetFlaggedProduct();
            return product;
        }
        internal void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }

    }
}
