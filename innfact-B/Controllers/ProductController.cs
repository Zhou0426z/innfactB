using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using innfact_B.Models;
using innfact_B.Service;
using innfact_B.ViewModels.Out;
namespace innfact.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductService productService;
        public ProductController(InnfactContext _db)
        {
            productService = new ProductService(_db);
        }
        [HttpGet]
        public OutProductsVM GetProduct(string productNo)
        {
           return productService.GetProduct(productNo);
        }
        [HttpGet]
        public IEnumerable<OutAboutProductsVM> GetAboutProducts(Guid productID)
        {
            return productService.GetAboutProducts(productID);
        }
    }
}