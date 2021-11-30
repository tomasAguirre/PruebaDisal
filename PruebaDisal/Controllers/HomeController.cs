using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaDisal.Models;

namespace PruebaDisal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductRepository productRepo;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepo)
        {
            _logger = logger;
            this.productRepo = productRepo;
        }

        public IActionResult Index()
        {
            var products = productRepo.selectProducts();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }       
        public IActionResult Producto()
        {
            var products = productRepo.selectProducts();
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [Route("saveProduct")]
        public IActionResult saveProduct(Product product) {
            productRepo.saveProduct(product);
            return Ok();
        }

        public IActionResult updateProduct(Product product)
        {
            
            productRepo.updateProduct(product);
            return Ok();
        }

        public IActionResult deletProduct(Product product)
        {
            productRepo.deletProduct(product);
            return Ok();
        }

        [HttpGet]

        public IActionResult selectProducts()
        {
            var products = productRepo.selectProducts();
            return View(products);
        }

    }
}
