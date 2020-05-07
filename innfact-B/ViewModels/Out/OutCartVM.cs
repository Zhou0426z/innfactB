using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace innfact_B.ViewModels.Out
{
    public class OutCartVM
    {
        public Guid CartID { get; set; }
        public string ImageUrl { get; set; }
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
