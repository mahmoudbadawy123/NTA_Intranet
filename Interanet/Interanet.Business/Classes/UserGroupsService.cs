using Interanet.Business.Interfaces;
using Interanet.DataAccessLayer.Interfaces;
using Interanet.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Business.Classes
{
    public class UserGroupsService : IUserGroupsService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserGroupsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable< UserGroups>> GetAllGroups()
        {
           return _unitOfWork.UserGroups.GetAllAsync();
        }
    }
}
