using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace innfact_B.Models
{
    public partial class Accounts
    {
        public Accounts()
        {
            Carts = new HashSet<Carts>();
            Favorite = new HashSet<Favorite>();
            Orders = new HashSet<Orders>();
        }

        public Guid AccountId { get; set; }
        public Guid RoleId { get; set; }
        public string LineID { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public string Subscribe { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDay { get; set; }
        public string LoginBy { get; set; }
        [JsonIgnore]
        public virtual Roles Role { get; set; }
        [JsonIgnore]

        public virtual ICollection<Carts> Carts { get; set; }
        [JsonIgnore]

        public virtual ICollection<Favorite> Favorite { get; set; }
        [JsonIgnore]

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
