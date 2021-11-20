using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Models;

namespace WebApp_Cubits.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            var categoryList = new List<Category>();

            categoryList.Add(new Category
            {
                Id = 1,
                Name = category.Name
            });

            return View("Index");
        }
    }
}
