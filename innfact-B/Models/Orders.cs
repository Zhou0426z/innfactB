using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace innfact_B.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public Guid OrderId { get; set; }
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

        public virtual Accounts Account { get; set; }
        [JsonIgnore]

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
