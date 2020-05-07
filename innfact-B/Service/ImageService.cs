using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using innfact_B.Models;

namespace innfact_B.Service
{
    public class ImageService
    {
        private readonly InnfactContext db;
        public ImageService(InnfactContext _db)
        {
            db = _db;
        }
        public IEnumerable<Image> ByCategory(string imageCategory)
        {
            return db.Image.Where(x => x.ImageCategory == imageCategory);
        }
    }
}
