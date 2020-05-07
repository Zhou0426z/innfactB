using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace innfact_B.ViewModels.Out
{
    public class OutCollectionProductsVM
    {
        public string ProductName { get; set; } 
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string CategoryName { get; set; }
        public Guid ProductID { get; set; }

        public string ProductNo { get; set; }
    }
}
