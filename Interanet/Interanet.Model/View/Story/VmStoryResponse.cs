using Interanet.Model.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Model.View.Story
{

    public class VmGetAdminStoryResponse
    {
        public List<VmStoryResponse> Data { get; set; }
        public Page Page { get; set; }

    }


    public class VmGetAdminStoryServiceResponse
    {
        public List<Storys> Data { get; set; }
        public Page Page { get; set; }

    }


    public class VmStoryResponse
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
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



    public class VmAddStoryRequest
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public int? GroupId { get; set; }
        public bool? isScheduledPublish { get; set; }
        public DateTime? PublishDateTime { get; set; }
 
    }

    public class VmUpdateStoryRequest
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Body { get; set; }
        public int? GroupId { get; set; }
        public bool? isScheduledPublish { get; set; }
        public DateTime? PublishDateTime { get; set; }

    }



    public class VmDeleteStoryRequest
    {
        public int Id { get; set; }
    }

}
