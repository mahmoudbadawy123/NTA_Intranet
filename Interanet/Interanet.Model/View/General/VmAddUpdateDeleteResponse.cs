using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Model.View.General
{
    public class VmAddUpdateDeleteResponse
    {
        public bool IsDone { get; set; } = false;
        public string Message { get; set; }  = "Some thing wrong happened while Processing Function";
    }
}
