using FEL_JAMIRA_WEB_APP.Models.Areas.Estacionamento;
using FEL_JAMIRA_WEB_APP.Models.Areas.Modelagem_do_Sistema;
using FEL_JAMIRA_WEB_APP.Models.Areas.Util;
using FEL_JAMIRA_WEB_APP.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FEL_JAMIRA_WEB_APP.Controllers
{
    //[Authorize]
    public class EstacionamentoController : BaseController<Pessoa>
    {
        // GET: MeusDados
        public ActionResult MeusDados()
        {
            ViewBag.Cidade = Helpers.GetSelectList("Cidades") as SelectList;
            ViewBag.Estado = Helpers.GetSelectList("Estados") as SelectList;
            return View();
        }

        public async Task<JsonResult> GetRecebimentos()
        {
            BaseController<Recebimentos> baseController = new BaseController<Recebimentos>();
            ResponseViewModel<Recebimentos> retorno = new ResponseViewModel<Recebimentos>();
            int UsuarioLogado = GetIdUsuario();
            retorno = await baseController.PostObject(UsuarioLogado,"Estacionamentos/GetRecebimentos");
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CadastrarEstacionamento()
        {
            ViewBag.Cidade = Helpers.GetSelectList("Cidades") as SelectList;
            ViewBag.Estado = Helpers.GetSelectList("Estados") as SelectList;
            return PartialView("~/Views/Estacionamento/CadastrarEstacionamento.cshtml");
        }
    }
}