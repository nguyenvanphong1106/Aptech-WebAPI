using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JWT_Authentication
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public enum UserRole
        {
            Normal,
            Admin
        }
    }
}