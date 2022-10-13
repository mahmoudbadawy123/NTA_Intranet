using Interanet.Model.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Model.View.Announcement
{

    public class VmGetAdminAnnouncementResponse
    {
        public List<VmAnnouncementResponse> Data { get; set; }
        public Page Page { get; set; }

    }


    public class VmGetAdminAnnouncementServiceResponse
    {
        public List<Data.Announcement> Data { get; set; }
        public Page Page { get; set; }

    }


    public class VmAnnouncementResponse
    {
        public int Id { get; set; }
        public string LabelName { get; set; }
        public string MessageBody { get; set; }
        public int? GroupId { get; set; }
        public string?  UserGroupName { get; set; }
        public bool? isScheduledPublish { get; set; } 
        public DateTime? PublishDateTime { get; set; }
        public DateTime? InsertUserDate { get; set; }
        public DateTime? UpdateUserDate { get; set; }
        [StringLength(450)]
        public string? InsertUserId { get; set; }
        [StringLength(450)]
        public string? UpdateUserId { get; set; }
        public  string? InsertUserName { get; set; }
        public  string? UpdateUserName { get; set; }
    }



    public class VmAddAnnouncementRequest
    {
        public string LabelName { get; set; }
        public string MessageBody { get; set; }
        public int? GroupId { get; set; }
        public bool? isScheduledPublish { get; set; }
        public DateTime? PublishDateTime { get; set; }
 
    }

    public class VmUpdateAnnouncementRequest
    {
        public int Id { get; set; }
        public string LabelName { get; set; }
        public string MessageBody { get; set; }
        public int? GroupId { get; set; }
        public bool? isScheduledPublish { get; set; }
        public DateTime? PublishDateTime { get; set; }

    }



    public class VmDeleteAnnouncementRequest
    {
        public int Id { get; set; }
    }

}
