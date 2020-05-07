using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace innfact_B.Models
{
    public partial class OrderDetails
    {
        public Guid OrderDetailId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal? Discount { get; set; }
        [JsonIgnore]

        public virtual Orders Order { get; set; }
        [JsonIgnore]

        public virtual Products Product { get; set; }
    }
}
