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
        public IBaseRepository<UserGroups> UserGroups { get; private set; }
        public IBaseRepository<Announcements> Announcements { get; private set; }
        public IBaseRepository<Storys> Storys { get; private set; }
        public IBaseRepository<CalenderEvents> CalenderEvents { get; private set; }
        public IBaseRepository<MeetingTypes> MeetingTypes { get; private set; }
        public IBaseRepository<Meeting> Meetings { get; private set; }
        public IBaseRepository<Systems> Systems { get; private set; }
        public IBaseRepository<ApplicationUserMeeting> ApplicationUserMeetings { get; private set; }

        
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ApplicationUser = new BaseRepository<ApplicationUser>(_context);
            UserGroups = new BaseRepository<UserGroups>(_context);
            Announcements = new BaseRepository<Announcements>(_context);
            Storys = new BaseRepository<Storys>(_context);
            CalenderEvents = new BaseRepository<CalenderEvents>(_context);
            MeetingTypes = new BaseRepository<MeetingTypes>(_context);
            Meetings = new BaseRepository<Meeting>(_context);
            Systems = new BaseRepository<Systems>(_context);
            
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