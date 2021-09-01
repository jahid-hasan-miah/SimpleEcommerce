using ECommerceSystem.Api.Models;
using ECommerceSystem.ProductManaging.BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var model = new ProductListModel();
            var product = model.Get().ToList();
            return product;
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = new EditProductModel();
            return product.Get(id);    
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromForm] Product product)
        {
            var prod = new AddProductModel();
            prod.ProductName = product.ProductName;
            prod.Price = (int)product.Price;
            if (ModelState.IsValid)
            {
                prod.AddNewProduct();
            }
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] Product model)
        {
            var product = new EditProductModel();
            product.LoadModelData(id);
            if(product is null)
            {
                Console.WriteLine("not availble");
            }
            if (product.DeleteFlag == 1)
            {
                Console.WriteLine("not availble");
            }
            else
            {
                product.ProductName = model.ProductName;
                product.Price = (int?)model.Price;
                product.Update();
            }
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = new EditProductModel();
            product.LoadModelData(id);
            product.DeleteFlag = 1;
            product.Update();
        }
    }
}
