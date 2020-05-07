using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using innfact_B.Service;
using innfact_B.Models;
namespace innfact.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IndexController : ControllerBase
    {
        private ImageService imageService;
        private CategoryService categoryService;
        public IndexController(InnfactContext _db)
        {
            imageService = new ImageService(_db);
            categoryService = new CategoryService(_db);

        }
        [HttpGet]
        public IEnumerable<Image> GetImageByCategory(string category)
        {
            return imageService.ByCategory(category);
        }
        [HttpGet]
        public IEnumerable<Categories> GetHeaderCategories()
        {
            return categoryService.GetHeaderCategories();
        }
    }
}