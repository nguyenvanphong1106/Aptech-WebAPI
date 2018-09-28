using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebAPI_Authorize.Models;

namespace WebAPI_Authorize.Controllers
{
    public class HomeController : Controller
    {
        EShopDBEntities db = new EShopDBEntities();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        //LOGIN
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]      //kiem tr so sanh vs antiforeintoken ben cshtml (khi F5 se tao tung token)
        public ActionResult Login(Employess data)
        {
            var em = db.Employesses.Where(x => x.LoginName.Equals(data.LoginName) && x.Password.Equals(data.Password)).SingleOrDefault();
            if(em != null)
            {
                //OK
                FormsAuthentication.SetAuthCookie(em.Id.ToString(), false);
                return RedirectToAction("Index");
            }
            else
            {

            }

            return View();
        }

        //LOGOUT
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}
