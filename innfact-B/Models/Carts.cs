using System;
using System.Collections.Generic;

namespace innfact_B.Models
{
    public partial class Carts
    {
        public Guid CartId { get; set; }
        public Guid AccountId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Accounts Account { get; set; }
        public virtual Products Product { get; set; }
    }
}
