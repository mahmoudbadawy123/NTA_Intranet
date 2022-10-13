using Interanet.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Business.Interfaces
{
    public interface IMeetingTypesService
    {
        Task<IEnumerable<MeetingType>> GetAllMeetingTypes();
    }
}
