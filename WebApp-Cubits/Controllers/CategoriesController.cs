using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
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
        
        public IActionResult Edit()
        {
            return View();
        }
        
        public IActionResult Delete()
        {
            return View();
        }
    }
}
