using Interanet.Model.Data;
using Interanet.Model.View;
using Interanet.Model.View.General;
using Interanet.Model.View.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Business.Interfaces
{
    public interface ISystemsService
    {
        Task<VmAddUpdateDeleteResponse> Add(Systems Request, VmUserData UserData);
        Task<VmAddUpdateDeleteResponse> Update(VmUpdateSystemRequest Request, VmUserData UserData);
        Task<VmAddUpdateDeleteResponse> Delete(VmDeleteSystemRequest Request);
        Task<VmGetAdminSystemServiceResponse> GetAllForAdmin(Page Page);
        Task<VmGetAdminSystemServiceResponse> GetAllForEmployee(string  UserId);
    }
}
