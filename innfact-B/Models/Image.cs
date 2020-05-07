using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace innfact_B.Models
{
    public partial class Image
    {
        public Guid ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string GoToUrl { get; set; }
        public Guid? ForProductNo { get; set; }
        public string ImageCategory { get; set; }
        [JsonIgnore]
        public virtual Products ForProductNoNavigation { get; set; }
    }
}
