using AutoMapper;
using ECommerceSystem.ProductManaging.BusinessObjects;
using ECommerceSystem.ProductManaging.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceSystem.ProductManaging.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductUnitOfWork _productUnitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IProductUnitOfWork productUnitOfWork,
            IMapper mapper)
        {
            _productUnitOfWork = productUnitOfWork;
            _mapper = mapper;
        }
        public void AddNewProduct(Product product)
        {
            if (product == null)
                throw new("Product Required");

            _productUnitOfWork.Products.Add(
                _mapper.Map<Entities.Product>(product)
            );

            _productUnitOfWork.Save();
        }

        public void DeleteProduct(int id)
        {
            _productUnitOfWork.Products.Remove(id);
            _productUnitOfWork.Save();
        }

        public IList<Product> GetProduct()
        {
            var product = _productUnitOfWork.Products.GetAll();
            var productDetails = (from prod in product
                                  where prod.DeleteFlag != 1
                                  select _mapper.Map<BusinessObjects.Product>(prod)).ToList();
            return productDetails;
        }
        public Product GetFlaggedProduct(int id)
        {
            var product = _productUnitOfWork.Products.GetById(id);

            if (product == null) return null;
            if (product.DeleteFlag == 0) return null;
            var productDetails = _mapper.Map<BusinessObjects.Product>(product);
            return productDetails;
        }
        public Product GetProduct(int id)
        {
            var product = _productUnitOfWork.Products.GetById(id);

            if (product == null) return null;
            if (product.DeleteFlag == 1) return null;
            var productDetails = _mapper.Map<BusinessObjects.Product>(product);
            return productDetails;
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
                throw new InvalidOperationException("Product is Empty");

            var productEntity = _productUnitOfWork.Products.GetById(product.Id);

            if (productEntity != null)
            {
                _mapper.Map(product, productEntity);
                _productUnitOfWork.Save();
            }
            else
                throw new InvalidOperationException("Couldn't find Product");
        }

        public IList<Product> GetFlaggedProduct()
        {
            var product = _productUnitOfWork.Products.GetAll();
            var productDetails = (from prod in product
                                  where prod.DeleteFlag != 0
                                  select _mapper.Map<BusinessObjects.Product>(prod)).ToList();
            return productDetails;
        }
    }
}
