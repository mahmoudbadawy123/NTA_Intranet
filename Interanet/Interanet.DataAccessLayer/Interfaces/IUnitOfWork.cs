using Interanet.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<ApplicationUser> ApplicationUser { get; }
        IBaseRepository<UserGroups> UserGroups { get; }
        IBaseRepository<Announcements> Announcements { get; }
        IBaseRepository<Storys> Storys { get; }
        IBaseRepository<CalenderEvents> CalenderEvents { get; }
        IBaseRepository<MeetingTypes> MeetingTypes { get; }
        IBaseRepository<Meeting> Meetings { get; }
        IBaseRepository<Systems> Systems { get; }
        IBaseRepository<ApplicationUserMeeting> ApplicationUserMeetings { get; }
        
        int Complete();
    }
}