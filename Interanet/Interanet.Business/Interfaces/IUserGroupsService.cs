using Interanet.Model.Data;
using Interanet.Model.View.LookUps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Business.Interfaces
{
    public interface IUserGroupsService
    {
        Task<IEnumerable<UserGroups>> GetAllGroups();
    }
}
