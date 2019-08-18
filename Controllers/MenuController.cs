using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FEL_JAMIRA_WEB_APP.Controllers
{
    
    public class MenuController : Controller
    {
        // GET: BuscarValor
        public async Task<JsonResult> BuscarValor(string username = "")
        {
            //var ida = Request["id"]; 
            var resultado = new
            {
                Nome = "Linha de Código: " + username.ToString(),
                URL = "www.linhadecodigo.com.br"
            };
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        // GET: MenuDoCliente
        //[Authorize]
        public ActionResult Cliente()
        {
            return View();
        }

        // GET: MenuDoFornecedor
        public ActionResult Estacionamento()
        {
            return View();
        }
    }
}