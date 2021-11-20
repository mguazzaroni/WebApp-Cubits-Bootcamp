using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_Cubits.Models;

namespace WebApp_Cubits.Controllers
{
    public class ProvidersController : Controller
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
        public IActionResult Create(Provider provider)
        {
            var providerList = new List<Provider>();

            providerList.Add(new Provider
            {
                Id = 0,
                Name = provider.Name,
                Description = provider.Description,
                Address = provider.Address
            });

            return View("Index", providerList);
        }
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Edit(Provider provider)
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
