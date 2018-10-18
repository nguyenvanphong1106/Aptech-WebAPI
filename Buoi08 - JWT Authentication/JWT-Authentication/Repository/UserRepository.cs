using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JWT_Authentication;

namespace JWT_Authentication
{
    public class UserRepository
    {
        public List<User> TestUsers;
        public UserRepository()
        {
            TestUsers = new List<User>();
            TestUsers.Add(new User() { UserName = "user01", Password = "123456" });
            TestUsers.Add(new User() { UserName = "user02", Password = "123456" });
        }

        public User GetUser(string username)
        {
            try
            {
                return TestUsers.First(user => user.UserName.Equals(username));
            }
            catch
            {
                return null;
            }
        }
    }
}