using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Model.Data
{
    public class Meeting
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Required]
        public string MeatingName { get; set; }
        [Required]
        public string Description { get; set; }
        public string? MeatingLocation { get; set; }

        public string? MeatingLink { get; set; }
        public DateTime? MeatingDateTime { get; set; } = DateTime.UtcNow.ToLocalTime();
        public int? MeatingTypeId { get; set; }
        [ForeignKey("MeatingTypeId")]
        public virtual MeetingType MeetingTypes { get; set; }
        public bool? isScheduledPublish { get; set; } = false;
        public DateTime? PublishDateTime { get; set; } = DateTime.UtcNow.ToLocalTime();
        public DateTime? InsertUserDate { get; set; }
        public DateTime? UpdateUserDate { get; set; }
        [StringLength(450)]
        public string? InsertUserId { get; set; }
        [StringLength(450)]
        public string? UpdateUserId { get; set; }

        [ForeignKey("InsertUserId")]
        public virtual ApplicationUser ApplicationUser_InsertUser { get; set; }
        [ForeignKey("UpdateUserId")]
        public virtual ApplicationUser ApplicationUser_UpdateUser { get; set; }

//###########################################################################################

        //[StringLength(450)]
        //public string? RecieverUserId { get; set; }
        
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public virtual List<ApplicationUserMeeting> ApplicationUserMeetings { get; set; }


    }
}
