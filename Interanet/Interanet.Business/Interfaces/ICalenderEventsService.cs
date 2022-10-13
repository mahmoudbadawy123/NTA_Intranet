using Interanet.Model.Data;
using Interanet.Model.View.Calender;
using Interanet.Model.View.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Business.Interfaces
{
    public interface ICalenderEventsService
    {
        Task<VmAddUpdateDeleteResponse> Add(CalenderEvent Request, VmEventUserData UserData);
        Task<VmAddUpdateDeleteResponse> Update(VmUpdateCalenderEventRequest Request, VmEventUserData UserData);
        Task<VmAddUpdateDeleteResponse> Delete(VmDeleteCalenderEventRequest Request);
        Task<VmGetAdminCalenderEventServiceResponse> GetAllForAdmin();
        Task<VmGetAdminCalenderEventServiceResponse> GetAllForEmployeesByGroup(int GroupId);
    }
}
