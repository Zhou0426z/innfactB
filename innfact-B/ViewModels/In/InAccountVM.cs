using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace innfact_B.ViewModels.In
{
    public class InAccountVM
    {
        public Guid AccountID { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDay { get; set; }
        public string LoginBy { get; set; }

        public string Phone { get; set; }

        public string Gender { get; set; }
        public string Subscribe { get; set; }

        public string Token { get; set; }
    }
}
