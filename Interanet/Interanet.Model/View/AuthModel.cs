using System;
using System.Collections.Generic;

namespace Interanet.Model.View
{
    public class AuthModel
    {
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }

        public bool IsFirstlogin { get; set; }

        public int UserType { get; set; }

        public string Fullname { get; set; }

        public int? GroupId { get; set; }
        public string? GroupName { get; set; } = "Admin";
    }
}