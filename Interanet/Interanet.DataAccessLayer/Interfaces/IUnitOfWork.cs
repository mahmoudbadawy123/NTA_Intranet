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
        IBaseRepository<UserGroup> UserGroups { get; }
        IBaseRepository<Announcement> Announcements { get; }
        IBaseRepository<Story> Storys { get; }
        IBaseRepository<CalenderEvent> CalenderEvents { get; }
        IBaseRepository<MeetingType> MeetingTypes { get; }
        IBaseRepository<Meeting> Meetings { get; }
        IBaseRepository<ApplicationUserMeeting> ApplicationUserMeetings { get; }

        //DbRawSqlQuery<T> ExecQuery<T>(string query);
        int Complete();
    }
}