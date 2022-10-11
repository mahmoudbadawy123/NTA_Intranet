using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interanet.Model.Data;

namespace Interanet.Model.View.Meetings
{
    public class VmMeetingResponse
    {
        public int Id { get; set; }
        public string MeatingName { get; set; }
        public string Description { get; set; }
        public string MeatingLocation { get; set; }
        public string MeatingLink { get; set; }
        public DateTime? MeatingDateTime { get; set; } = DateTime.UtcNow.ToLocalTime();
        [StringLength(450)]
        //public ICollection<VmRecieverUserRequest> RecieverUserIds { get; set; }
        public  List<VmApplicationUserMeeting> ApplicationUserMeetings { get; set; }

        public int? MeatingTypeId { get; set; }
        public bool? isScheduledPublish { get; set; } = false;
        public DateTime? PublishDateTime { get; set; } = DateTime.UtcNow.ToLocalTime();
        public DateTime? InsertUserDate { get; set; }
        public DateTime? UpdateUserDate { get; set; }
        [StringLength(450)]
        public string? InsertUserId { get; set; }
        [StringLength(450)]
        public string? UpdateUserId { get; set; }
        public string? InsertUserName { get; set; }
        public string? UpdateUserName { get; set; }
        //public string? RecieverUserName { get; set; }
        public string? MeatingTypeName { get; set; }
    }



    public class VmGetAdminMeetingResponse
    {
        public List<VmMeetingResponse> Data { get; set; }

    }


    public class VmGetAdminMeetingServiceResponse
    {
        public List<Meeting> Data { get; set; }

    }




    public class VmApplicationUserMeeting
    {
        public int MeetingId { get; set; }
        public string ApplicationUserId { get; set; }

    }






    public class VmAddMeetingRequest
    {
        public string MeatingName { get; set; }
        public string Description { get; set; }
        public string? MeatingLocation { get; set; }
        public string? MeatingLink { get; set; }
        public DateTime? MeatingDateTime { get; set; } = DateTime.UtcNow.ToLocalTime();
        public List<VmRecieverUserRequest> RecieverUserIds { get; set; }
        public int? MeatingTypeId { get; set; }
        public bool? isScheduledPublish { get; set; } = false;
        public DateTime? PublishDateTime { get; set; } = DateTime.UtcNow.ToLocalTime();
        public DateTime? InsertUserDate { get; set; }
        public DateTime? UpdateUserDate { get; set; }
        [StringLength(450)]
        public string? InsertUserId { get; set; }
        [StringLength(450)]
        public string? UpdateUserId { get; set; }
    }

    public class VmUpdateMeetingRequest
    {
        public int Id { get; set; }
        public string MeatingName { get; set; }
        public string Description { get; set; }
        public string? MeatingLocation { get; set; }
        public string? MeatingLink { get; set; }
        public DateTime? MeatingDateTime { get; set; } = DateTime.UtcNow.ToLocalTime();
        public List<VmRecieverUserRequest> RecieverUserIds { get; set; }
        public int? MeatingTypeId { get; set; }
        public bool? isScheduledPublish { get; set; } = false;
        public DateTime? PublishDateTime { get; set; } = DateTime.UtcNow.ToLocalTime();

    }



    public class VmDeleteMeetingRequest
    {
        public int Id { get; set; }
    }


    public class VmRecieverUserRequest
    {
        public string? Id { get; set; }
        public string? Name { get; set; }

    }

}

