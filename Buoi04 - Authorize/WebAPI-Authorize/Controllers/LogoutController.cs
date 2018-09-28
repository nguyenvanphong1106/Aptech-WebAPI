using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;

namespace WebAPI_Authorize.Controllers
{
    public class LogoutController : ApiController
    {
        [HttpGet]
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
