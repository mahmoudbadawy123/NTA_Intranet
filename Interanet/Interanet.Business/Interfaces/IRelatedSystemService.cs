using Interanet.Model.Data;
using Interanet.Model.View;
using Interanet.Model.View.General;
using Interanet.Model.View.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Business.Interfaces
{
    public interface IRelatedSystemService
    {
        Task<VmAddUpdateDeleteResponse> Add(VmAddRelatedSystemRequest Request, VmRelatedSystemData UserData);
        Task<VmAddUpdateDeleteResponse> Update(VmUpdateRelatedSystemRequest Request, VmRelatedSystemData UserData);
        Task<VmAddUpdateDeleteResponse> Delete(VmDeleteRelatedSystemRequest Request);
        Task<VmGetAdminRelatedSystemServiceResponse> GetAllForAdmin(Page Page);
        Task<VmGetAdminRelatedSystemServiceResponse> GetAllForEmp(string UserId , Page Page);

    }
}
