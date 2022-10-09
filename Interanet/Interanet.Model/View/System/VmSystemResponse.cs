using Interanet.Model.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Model.View.System
{
 
    public class VmGetAdminSystemResponse
    {
        public List<VmSystemResponse> Data { get; set; }
        public Page Page { get; set; }

    }


    public class VmGetAdminSystemServiceResponse
    {
        public List<Systems> Data { get; set; }
        public Page Page { get; set; }

    }


    public class VmSystemResponse
    {
        public int Id { get; set; }
        public string SystemName { get; set; }
        public string Link { get; set; }

        [StringLength(450)]
        public string EmployeeUserId { get; set; }
        public string? EmployeeName { get; set; }

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
    }



    public class VmAddSystemRequest
    {
        public string SystemName { get; set; }
        public string Link { get; set; }
        public string EmployeeUserId { get; set; }
        public bool? isScheduledPublish { get; set; }
        public DateTime? PublishDateTime { get; set; }

    }

    public class VmUpdateSystemRequest
    {
        public int Id { get; set; }
        public string SystemName { get; set; }
        public string Link { get; set; }
        public string EmployeeUserId { get; set; }
        public bool? isScheduledPublish { get; set; }
        public DateTime? PublishDateTime { get; set; }

    }



    public class VmDeleteSystemRequest
    {
        public int Id { get; set; }
    }

}

