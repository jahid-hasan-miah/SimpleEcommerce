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
    public class AddProductModel
    {
        [Required, MaxLength(50, ErrorMessage = "Name should be less than 50 charcaters")]
        public string ProductName { get; set; }
        [Required, Range(20, 10000)]
        public int Price { get; set; }

        private readonly IProductService _productService;

        public AddProductModel()
        {
            _productService = Startup.AutofacContainer.Resolve<IProductService>();
        }

        public AddProductModel(IProductService productService)
        {
            _productService = productService;
        }

        internal void AddNewProduct()
        {
            var product = new Product
            {
                ProductName = ProductName,
                Price = Price
            };

            _productService.AddNewProduct(product);
        }
    }
}
