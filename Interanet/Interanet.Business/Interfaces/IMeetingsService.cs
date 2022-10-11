using Interanet.Model.Data;
using Interanet.Model.View.General;
using Interanet.Model.View.Meetings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Business.Interfaces
{
    public interface IMeetingsService
    {
        Task<VmAddUpdateDeleteResponse> Add(VmAddMeetingRequest Request, VmMeetingData UserData);
        Task<VmAddUpdateDeleteResponse> Update(VmUpdateMeetingRequest Request, VmMeetingData UserData);
        Task<VmAddUpdateDeleteResponse> Delete(VmDeleteMeetingRequest Request);
        Task<List<Meeting>> GetAllForAdmin();
        Task<List<Meeting>> GetAllForEmp(string UserId);
    }
}
