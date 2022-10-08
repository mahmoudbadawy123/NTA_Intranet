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
        IBaseRepository<UserGroups> UserGroups { get; }
        IBaseRepository<Announcements> Announcements { get; }
        IBaseRepository<Storys> Storys { get; }
        IBaseRepository<CalenderEvents> CalenderEvents { get; }

        
        int Complete();
    }
}