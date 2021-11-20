using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Models;

namespace WebApp_Cubits.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            //var productsList = new List<Product>();


            //var lap = 0;

            //while (lap < 25)
            //{
            //    lap++;

            //    productsList.Add(new Product
            //    {
            //        Id = lap,
            //        Name = $"Producto",
            //        Description = $"Desc",
            //        Price = 123
            //    });
            //}

            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            var productsList = new List<Product>();

            productsList.Add(new Product
            {
                Id = 0,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price
            });

            return View("Index", productsList);
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            return View("Index");
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            return View("Index");
        }
    }
}
