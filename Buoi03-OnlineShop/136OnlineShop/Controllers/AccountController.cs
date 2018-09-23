using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using _136OnlineShop.Models;

namespace _136OnlineShop.Controllers
{
    public class AccountController : ApiController
    {
        EShopDBEntities db = new EShopDBEntities();

        //LOGIN
        [HttpPost]
        public IHttpActionResult CheckLogin(Employess data)
        {
            string ms = "";
            var em = db.Employesses.Where(x => x.LoginName.Equals(data.LoginName)).SingleOrDefault();
            if(em != null)
            {
                if(em.Password.Equals(data.Password))
                {
                    if (em.isActive)
                    {
                        FormsAuthentication.SetAuthCookie(em.Id.ToString(), false);
                        ms = "Login Sucessfully!";
                    }
                    else
                    {
                        ms = "Blocked!";
                    }
                }
                else
                {
                    ms = "Wrong Password!";
                }
            }
            else
            {
                ms = "Login Name does not exist!";
            }

            return Ok(ms);
        }

        //LOGOUT
        [HttpGet]
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }
    }
}
