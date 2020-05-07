using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace innfact_B.ViewModels.Out
{
    public class OutAboutProductsVM
    {
        public Guid ProductID { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public string ProductNo { get; set; }
    }
}
