using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace innfact_B.Models
{
    public partial class Products
    {
        public Products()
        {
            Carts = new HashSet<Carts>();
            Favorite = new HashSet<Favorite>();
            Image = new HashSet<Image>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public string ProductNo { get; set; }
        public int Stock { get; set; }

        [JsonIgnore]
        public virtual Categories Category { get; set; }
        [JsonIgnore]

        public virtual ICollection<Carts> Carts { get; set; }
        [JsonIgnore]

        public virtual ICollection<Favorite> Favorite { get; set; }
        [JsonIgnore]

        public virtual ICollection<Image> Image { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
