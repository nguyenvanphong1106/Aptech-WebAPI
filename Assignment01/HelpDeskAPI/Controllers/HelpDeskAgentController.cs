using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelpDeskAPI.Controllers
{
    public class HelpDeskAgentController : Controller
    {
        // GET: HelpDeskAgent
        public ActionResult Index()
        {
            return View();
        }
    }
}