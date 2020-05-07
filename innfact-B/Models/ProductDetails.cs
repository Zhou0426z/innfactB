using System;
using System.Collections.Generic;

namespace innfact_B.Models
{
    public partial class ProductDetails
    {
        public ProductDetails()
        {
            Carts = new HashSet<Carts>();
        }

        public Guid ProductDetailId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductDetailName { get; set; }
        public int Stock { get; set; }
        public string Specification { get; set; }

        public virtual Products Product { get; set; }
        public virtual ICollection<Carts> Carts { get; set; }
    }
}
