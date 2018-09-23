using SchoolWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace SchoolWebAPI.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        public void Login(LoginVM data)
        {
            if(data.UserName.Equals("karla2709") && data.Password.Equals("midway2709"))
            {
                FormsAuthentication.SetAuthCookie(data.UserName, false);
            }
        }
    }
}
