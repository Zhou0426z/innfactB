using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace innfact_B.ViewModels.Out
{
    public class OutFavoriteVM
    {
        public Guid favoriteID { get; set; }
        public Guid productID { get; set; }
        public string productName { get; set; }

        public decimal unitPrice { get; set; }

        public string imgUrl { get; set; }
    }
}
