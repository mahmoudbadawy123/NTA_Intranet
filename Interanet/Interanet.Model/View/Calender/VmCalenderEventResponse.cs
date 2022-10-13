using Interanet.Model.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Model.View.Calender
{
  
    
    public class VmGetAdminCalenderEventResponse
    {
        public List<VmCalenderEventResponse> Data { get; set; }

    }


    public class VmGetAdminCalenderEventServiceResponse
    {
        public List<CalenderEvent> Data { get; set; }

    }


    public class VmCalenderEventResponse
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public int? GroupId { get; set; }
        public string? UserGroupName { get; set; }
        public DateTime? EventDateTime { get; set; }
        public DateTime? InsertUserDate { get; set; }
        public DateTime? UpdateUserDate { get; set; }
        [StringLength(450)]
        public string? InsertUserId { get; set; }
        [StringLength(450)]
        public string? UpdateUserId { get; set; }
        public string? InsertUserName { get; set; }
        public string? UpdateUserName { get; set; }
    }



    public class VmAddCalenderEventRequest
    {
        public string EventName { get; set; }
        public string Description { get; set; }
        public int? GroupId { get; set; }
        public DateTime? EventDateTime { get; set; }

    }

    public class VmUpdateCalenderEventRequest
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public string Description { get; set; }
        public int? GroupId { get; set; }
        public DateTime? EventDateTime { get; set; }

    }



    public class VmDeleteCalenderEventRequest
    {
        public int Id { get; set; }
    }

}

