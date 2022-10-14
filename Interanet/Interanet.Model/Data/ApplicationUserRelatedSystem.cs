using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Interanet.Model.Data
{
    public class ApplicationUserRelatedSystem
    {
        public int RelatedSystemId { get; set; }
        [ForeignKey("RelatedSystemId")]

        [JsonIgnore]
        public virtual RelatedSystem RelatedSystem { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]

        [JsonIgnore]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
