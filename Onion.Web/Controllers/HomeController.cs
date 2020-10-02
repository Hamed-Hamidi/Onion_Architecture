using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Oninon.Web.Services;
using Onion.Web.Models;
using Onion.Web.ViewModel;

namespace Onion.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductsClient _products;
        public HomeController(ILogger<HomeController> logger , IProductsClient products )
        {
            _logger = logger;
            _products = products;
        }

        public async Task<IActionResult> Index(string name) {
          var model=new ProductViewModel().ProductDtos;
            if(string.IsNullOrWhiteSpace(name))
            model = await _products.GetAsync();
            else
                model = await _products.GetByNameAsync(name);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
         
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto product)
        {

            await _products.PostAsync(product);
            return RedirectToAction(nameof(Index));
        }




        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var product = await _products.GetByIdAsync(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDto product)
        {
            await _products.PutAsync(product);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _products.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
