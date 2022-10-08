using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Model.Interfaces
{
    public interface IEntityBase
    {
        public int? InsertUserId { get; set; }
        public DateTime? InsertUserDate { get; set; }
        public int? UpdateUserId { get; set; }
        public DateTime? UpdateUserDate { get; set; }

    }
}
