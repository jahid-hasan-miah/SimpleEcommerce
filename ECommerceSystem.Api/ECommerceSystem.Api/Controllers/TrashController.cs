using ECommerceSystem.Api.Models;
using ECommerceSystem.ProductManaging.BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrashController : ControllerBase
    {
        // GET: api/<TrashController>
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            var model = new ProductListModel();
            var product = model.GetTrash().ToList();
            return product;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = new EditProductModel();
            return product.GetFlaggedProduct(id);
        }

        // PUT api/<TrashController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromForm] Product model)
        {
            var product = new EditProductModel();
            product.LoadFlaggedModelData(id);
            product.ProductName = model.ProductName;
            product.Price = (int?)model.Price;
            product.DeleteFlag = model.DeleteFlag;
            product.Update();
        }

        // DELETE api/<TrashController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var model = new ProductListModel();
            model.Delete(id);
        }
    }
}
