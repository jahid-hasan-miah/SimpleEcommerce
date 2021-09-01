using Autofac;
using ECommerceSystem.ProductManaging.BusinessObjects;
using ECommerceSystem.ProductManaging.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceSystem.Api.Models
{
    public class EditProductModel
    {
        [Required, Range(1, 10000)]
        public int? Id { get; set; }
        [Required, MaxLength(200, ErrorMessage = "Name should be less than 20 charcaters")]
        public string ProductName { get; set; }
        [Required, Range(20, 50000)]
        public int? Price { get; set; }

        public int DeleteFlag { get; set; }

        private readonly IProductService _productService;

        public EditProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }

        public void LoadModelData(int id)
        {
            var product = _productService.GetProduct(id);
            Id = product?.Id;
            ProductName = product?.ProductName;
            Price = (int?)(product?.Price);
        }
        public void LoadFlaggedModelData(int id)
        {
            var product = _productService.GetFlaggedProduct(id);
            Id = product?.Id;
            ProductName = product?.ProductName;
            Price = (int?)(product?.Price);
        }

        public Product Get(int id)
        {
            var product = _productService.GetProduct(id);
            return product;
        }
        public Product GetFlaggedProduct(int id)
        {
            var product = _productService.GetFlaggedProduct(id);
            return product;
        }

        internal void Update()
        {
            var product = new Product
            {
                Id = Id.HasValue ? Id.Value : 0,
                ProductName = ProductName,
                Price = Price.HasValue ? Price.Value : 0,
                DeleteFlag = DeleteFlag
            };
            _productService.UpdateProduct(product);
        }
    }
}
