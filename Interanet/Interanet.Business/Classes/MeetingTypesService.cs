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
    public class MeetingTypesService : IMeetingTypesService
    {


        private readonly IUnitOfWork _unitOfWork;
        public MeetingTypesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<MeetingType>> GetAllMeetingTypes()
        {
            return _unitOfWork.MeetingTypes.GetAllAsync();

        }

    }
}
