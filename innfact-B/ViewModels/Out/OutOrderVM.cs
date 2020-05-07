using innfact_B.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace innfact_B.ViewModels.Out
{
    public class OutOrderVM
    {
        public Guid OrderID { get; set; }
        public string ShipAddress { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime OrderDate { get; set; }

        public bool HasPay { get; set; }

        public List<OutOrderDetailVM> OrderDetails { get; set; }
    }
}
