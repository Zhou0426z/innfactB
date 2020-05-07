using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace innfact_B.ViewModels.In
{
    public class InOrderVM
    {
        public Guid AccountId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipVia { get; set; }
        public decimal Freight { get; set; }
        public string ShipCity { get; set; }
        public string ShipAddress { get; set; }
        public string PayWay { get; set; }
        public string HasPay { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string InvoiceWay { get; set; }
        public string Remark { get; set; }

    }
}
