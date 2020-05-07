using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace innfact_B.ViewModels.In
{
    public class InPasswordVM
    {
        public Guid AccountID { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
