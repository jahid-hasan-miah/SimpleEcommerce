using ECommerceSystem.Web.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerceSystem.Web.Controllers
{
    [Authorize(policy: "UserAccess")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> productList = new List<Product>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44319/api/product"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productList = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }
            }
            return View(productList);
        }

        public async Task<IActionResult> EditProduct(int id, bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            Product product = new Product();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44319/api/product/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    product = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            Product modelProduct = new Product();
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(product.Id.ToString()), "Id");
                content.Add(new StringContent(product.ProductName), "ProductName");
                content.Add(new StringContent(product.Price.ToString()), "Price");

                using (var response = await httpClient.PutAsync("https://localhost:44319/api/product/" + product.Id, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    modelProduct = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return (RedirectToAction(nameof(EditProduct), new { isSuccess = true }));
        }

        public IActionResult AddProduct(bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            Product modelProduct = new Product();
            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(product.ProductName), "ProductName");
                content.Add(new StringContent(product.Price.ToString()), "Price");

                using (var response = await httpClient.PostAsync("https://localhost:44319/api/product", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    modelProduct = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return (RedirectToAction(nameof(AddProduct), new { isSuccess = true }));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44319/api/product/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
