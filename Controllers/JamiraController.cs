using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEL_JAMIRA_WEB_APP.Controllers
{
    [AllowAnonymous]
    public class JamiraController : Controller
    {
        // GET: Jamira
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}