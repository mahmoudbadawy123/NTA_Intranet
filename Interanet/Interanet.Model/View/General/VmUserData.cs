using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Model.View.General
{
    public class VmUserData
    {
        public string UserId { get; set; }
        public DateTime? PublishDateTime { get; set; }
    }


    public class VmEventUserData
    {
        public string UserId { get; set; }
        public DateTime? EventDateTime { get; set; }
    }


    public class VmMeetingData
    {
        public string UserId { get; set; }
        public DateTime? PublishDateTime { get; set; }
        public DateTime? MeatingDateTime { get; set; }
    }


    public class VmRelatedSystemData
    {
        public string UserId { get; set; }
        public DateTime? PublishDateTime { get; set; }
    }
}
