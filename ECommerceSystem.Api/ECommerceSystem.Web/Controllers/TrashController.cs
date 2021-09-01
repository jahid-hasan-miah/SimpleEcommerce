using ECommerceSystem.Web.Models.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerceSystem.Web.Controllers
{
    [Authorize(policy: "UserAccess")]
    public class TrashController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            List<Product> productList = new List<Product>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44319/api/trash"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    productList = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }
            }
            return View(productList);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44319/api/trash/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RecoverProduct(int id)
        {
            Product modelProduct = new Product();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44319/api/trash/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    modelProduct = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
                modelProduct.DeleteFlag = 0;
                var content = new MultipartFormDataContent();
                content.Add(new StringContent(modelProduct.Id.ToString()), "Id");
                content.Add(new StringContent(modelProduct.ProductName), "ProductName");
                content.Add(new StringContent(modelProduct.Price.ToString()), "Price");
                content.Add(new StringContent(modelProduct.DeleteFlag.ToString()), "DeleteFlag");

                using (var response = await httpClient.PutAsync("https://localhost:44319/api/trash/" + id, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    modelProduct = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return (RedirectToAction(nameof(Index)));
        }
    }
}
