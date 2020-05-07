using innfact_B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace innfact_B.Service
{
    public class CategoryService
    {
        private readonly InnfactContext db;
        public CategoryService(InnfactContext _db)
        {
            db = _db;
        }
        public IEnumerable<Categories> GetHeaderCategories()
        {
            var value = db.Categories.OrderBy(x=>x.CategoryName);
            if(value.Count()>6)
            {
                return value.Take(6);
            }
            else
            {
                return value;
            }
        }
        public IEnumerable<Categories> GetAllCategories()
        {
            return db.Categories.OrderBy(x=>x.CategoryName);
        }
    }
}
