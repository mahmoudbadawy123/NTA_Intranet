using Interanet.Model.Data;
using Interanet.Model.View;
using Interanet.Model.View.General;
using Interanet.Model.View.Story;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Business.Interfaces
{
    public interface IStorysService
    {
        Task<VmAddUpdateDeleteResponse> Add(Story Request, VmUserData UserData);
        Task<VmAddUpdateDeleteResponse> Update(VmUpdateStoryRequest Request, VmUserData UserData);
        Task<VmAddUpdateDeleteResponse> Delete(VmDeleteStoryRequest Request);
        Task<VmGetAdminStoryServiceResponse> GetAllForAdmin(Page Page);
        Task<VmGetAdminStoryServiceResponse> GetAllForEmployeesByGroup(int GroupId, Page Page);
    }
}

