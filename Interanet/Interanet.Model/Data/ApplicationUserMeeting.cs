using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Interanet.Model.Data
{
    public class ApplicationUserMeeting
    {
        //[Key]
        //public int Id { get; set; }
        public int MeetingId { get; set; }
        [ForeignKey("MeetingId")]

        [JsonIgnore]
        public virtual Meeting Meeting { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]

        [JsonIgnore]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
