using System;
using System.Collections.Generic;

namespace innfact_B.Models
{
    public partial class Roles
    {
        public Roles()
        {
            Accounts = new HashSet<Accounts>();
        }

        public Guid RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
    }
}
