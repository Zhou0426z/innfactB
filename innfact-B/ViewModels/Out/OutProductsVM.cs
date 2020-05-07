using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using innfact_B.Models;
namespace innfact_B.ViewModels.Out
{
    public class OutProductsVM
    {
        public Guid ProductID { get; set; }
        public List<string> ImageSilders { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }

        public int Stock { get; set; }
        public string ProductNo { get; set; } 
    }
}
