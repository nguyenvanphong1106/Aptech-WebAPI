using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using WebAPI_Authorize.Models;

namespace WebAPI_Authorize.Controllers
{

    public class LoginController : ApiController
    {
        EShopDBEntities db = new EShopDBEntities();
        
        //POST: /api/Login
        [HttpPost]
        public IHttpActionResult CheckLogin(Employess data)
        {
            var em = db.Employesses.Where(x => x.LoginName.Equals(data.LoginName) && x.Password.Equals(data.Password)).SingleOrDefault();
            if (em != null)
            {
                //LOGIN OK
                FormsAuthentication.SetAuthCookie(em.Id.ToString(), false);
                return Ok(em);
            }
            else
            {
                return NotFound();
            }        
        }
    }
}
