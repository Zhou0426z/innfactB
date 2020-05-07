using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using innfact_B.Models;
using innfact_B.ViewModels.Out;
namespace innfact_B.Service
{
    public class ProductService
    {
        private readonly InnfactContext db;
        public ProductService(InnfactContext _db)
        {
            db = _db;
        }
        public IEnumerable<OutCollectionProductsVM> GetCollectionProducts(string category)
        {
            var result = from p in db.Products
                        join c in db.Categories
                        on p.CategoryId equals c.CategoryId
                        where c.RouteName == category
                        select new OutCollectionProductsVM
                        {
                            ProductID = p.ProductId,
                            ProductName = p.ProductName,
                            Description = p.Description,
                            ImageUrl = db.Image.OrderBy(x=>x.ImageUrl).FirstOrDefault(x=>x.ForProductNo==p.ProductId).ImageUrl,
                            Price = p.Price,
                            CategoryName = c.CategoryName,
                            ProductNo = p.ProductNo
                        };
            return result.OrderBy(x=>x.ProductName);
        }
        public OutProductsVM GetProduct(string productNo)
        {
            var imageSilders = new List<string>();
            var productID = db.Products.FirstOrDefault(x => x.ProductNo == productNo).ProductId;
            foreach(var data in db.Image.Where(x => x.ForProductNo == productID))
            {
                imageSilders.Add(data.ImageUrl);
            }
            var result = from p in db.Products
                         where p.ProductId == productID
                         select new OutProductsVM
                         {
                             ProductID = p.ProductId,
                             ProductName = p.ProductName,
                             Brand = p.Brand,
                             Description = p.Description,
                             Price = p.Price,
                             ProductNo = p.ProductNo,
                             Stock = p.Stock,
                             ImageSilders = imageSilders,
                         };

            return result.FirstOrDefault();
        }
        public IEnumerable<OutAboutProductsVM> GetAboutProducts(Guid productID)
        {
            var categoryID = db.Products.FirstOrDefault(x => x.ProductId == productID).CategoryId;
            var result = from p in db.Products
                         where p.CategoryId == categoryID && p.ProductId != productID
                         select new OutAboutProductsVM
                         {
                             ProductID = p.ProductId,
                             ImageUrl = db.Image.OrderBy(x=>x.ImageUrl).FirstOrDefault(x=>x.ForProductNo == p.ProductId).ImageUrl,
                             Price = p.Price,
                             ProductName = p.ProductName,
                             ProductNo = p.ProductNo
                         };

            return result;

        }
    }
}
