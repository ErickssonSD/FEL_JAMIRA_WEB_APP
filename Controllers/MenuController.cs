using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FEL_JAMIRA_WEB_APP.Controllers
{
    
    public class MenuController : Controller
    {
        // GET: MenuDoCliente
        [Authorize]
        public ActionResult MenuDoCliente()
        {
            return View();
        }

        // GET: MenuDoFornecedor
        public ActionResult MenuDoFornecedor()
        {
            return View();
        }
    }
}