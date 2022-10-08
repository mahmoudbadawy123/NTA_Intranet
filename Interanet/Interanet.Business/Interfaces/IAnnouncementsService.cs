using Interanet.Model.Data;
using Interanet.Model.View;
using Interanet.Model.View.Announcement;
using Interanet.Model.View.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Business.Interfaces
{
    public interface IAnnouncementsService
    {
         Task<VmAddUpdateDeleteResponse> Add(Announcements Request, VmUserData UserData);
         Task<VmAddUpdateDeleteResponse> Update(VmUpdateAnnouncementRequest Request, VmUserData UserData);
         Task<VmAddUpdateDeleteResponse> Delete(VmDeleteAnnouncementRequest Request);
         Task<VmGetAdminAnnouncementServiceResponse> GetAllForAdmin(Page Page);
         Task<VmGetAdminAnnouncementServiceResponse> GetAllForEmployeesByGroup(int GroupId , Page Page);
    }
}
