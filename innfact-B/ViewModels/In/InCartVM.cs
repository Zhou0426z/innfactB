using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace innfact_B.ViewModels.In
{
    public class InCartVM
    {
        public Guid CartID { get; set; }

        public Guid ProductID { get; set; }

        public Guid AccountID { get; set; }
        public int Quantity { get; set; }


    }
}
