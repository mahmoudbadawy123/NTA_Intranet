using Interanet.DataAccessLayer.Interfaces;
using Interanet.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.DataAccessLayer.Class
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IBaseRepository<ApplicationUser> ApplicationUser { get; private set; }
        public IBaseRepository<UserGroup> UserGroups { get; private set; }
        public IBaseRepository<Announcement> Announcements { get; private set; }
        public IBaseRepository<Story> Storys { get; private set; }
        public IBaseRepository<CalenderEvent> CalenderEvents { get; private set; }
        public IBaseRepository<MeetingType> MeetingTypes { get; private set; }
        public IBaseRepository<Meeting> Meetings { get; private set; }
        public IBaseRepository<ApplicationUserMeeting> ApplicationUserMeetings { get; private set; }


        public IBaseRepository<RelatedSystem> RelatedSystems { get; private set; }
        public IBaseRepository<ApplicationUserRelatedSystem> ApplicationUserRelatedSystems { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ApplicationUser = new BaseRepository<ApplicationUser>(_context);
            UserGroups = new BaseRepository<UserGroup>(_context);
            Announcements = new BaseRepository<Announcement>(_context);
            Storys = new BaseRepository<Story>(_context);
            CalenderEvents = new BaseRepository<CalenderEvent>(_context);
            MeetingTypes = new BaseRepository<MeetingType>(_context);
            Meetings = new BaseRepository<Meeting>(_context);
            ApplicationUserMeetings = new BaseRepository<ApplicationUserMeeting>(_context);


            RelatedSystems = new BaseRepository<RelatedSystem>(_context);
            ApplicationUserRelatedSystems = new BaseRepository<ApplicationUserRelatedSystem>(_context);

        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}