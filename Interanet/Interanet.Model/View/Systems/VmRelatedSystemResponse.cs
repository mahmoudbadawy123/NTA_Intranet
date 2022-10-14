using Interanet.Model.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Model.View.Systems
{


    public class VmRelatedSystemResponse
    {
        public int Id { get; set; }
        public string SystemName { get; set; }
        public string Link { get; set; }
        public List<VmApplicationUserRelatedSystem> ApplicationUserRelatedSystems { get; set; }

        public bool? isScheduledPublish { get; set; } = false;
        public DateTime? PublishDateTime { get; set; } = DateTime.UtcNow.ToLocalTime();
        public DateTime? InsertUserDate { get; set; }
        public DateTime? UpdateUserDate { get; set; }
        public string? InsertUserId { get; set; }
        public string? UpdateUserId { get; set; }

        public string? InsertUserName { get; set; }
        public string? UpdateUserName { get; set; }

        //public string? employeeName { get; set; }
    }



    public class VmGetAdminRelatedSystemResponse
    {
        public List<VmRelatedSystemResponse> Data { get; set; }
        public Page Page { get; set; }
    }


    public class VmGetAdminRelatedSystemServiceResponse
    {
        public List<RelatedSystem> Data { get; set; }
        public Page Page { get; set; }

    }




    public class VmApplicationUserRelatedSystem
    {
        public int RelatedSystemId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }






    public class VmAddRelatedSystemRequest
    {
        [Required]
        public string SystemName { get; set; }
        [Required]
        public string Link { get; set; }
        public List<VmRelatedSystemRecieverUserRequest> RecieverUserIds { get; set; }
        public bool? isScheduledPublish { get; set; } = false;
        public DateTime? PublishDateTime { get; set; } = DateTime.UtcNow.ToLocalTime();

        public DateTime? InsertUserDate { get; set; }

        public string? InsertUserId { get; set; }


    }

    public class VmUpdateRelatedSystemRequest
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string SystemName { get; set; }
        [Required]
        public string Link { get; set; }
        public List<VmRelatedSystemRecieverUserRequest> RecieverUserIds { get; set; }
        public bool? isScheduledPublish { get; set; } = false;
        public DateTime? PublishDateTime { get; set; } = DateTime.UtcNow.ToLocalTime();
    }



    public class VmDeleteRelatedSystemRequest
    {
        public int Id { get; set; }
    }


    public class VmRelatedSystemRecieverUserRequest
    {
        public string? Id { get; set; }
        public string? Name { get; set; }

    }

}


