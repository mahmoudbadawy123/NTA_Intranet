using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Model.Data
{
    public class ApplicationUser : IdentityUser
    {
        [Required , StringLength(100)]
        public string FullName { get; set; }
        public int? GroupId { get; set; }

        [ForeignKey("GroupId")]
        public virtual UserGroup UserGroups { get; set; }

        public bool IsFirstlogin { get; set; } = false;

        //#########################################################################################

        public virtual ICollection<Meeting> Meetings { get; set; }
        public virtual List<ApplicationUserMeeting> ApplicationUserMeetings { get; set; }


    }
}
