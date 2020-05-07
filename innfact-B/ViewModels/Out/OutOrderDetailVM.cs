using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace innfact_B.ViewModels.Out
{
    public class OutOrderDetailVM
    {
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public string ProductName { get; set; }

    }
}
