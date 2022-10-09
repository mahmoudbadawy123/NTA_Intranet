using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interanet.Model.View
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int GroupId { get; set; }
        public IEnumerable<string> Roles { get; set; }

    }


    public class UserLookUpViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
