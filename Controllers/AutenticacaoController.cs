using FEL_JAMIRA_WEB_APP.Models;
using FEL_JAMIRA_WEB_APP.Models.Areas.Autenticacao;
using FEL_JAMIRA_WEB_APP.Models.Areas.Localizacao;
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
    [AllowAnonymous]
    public class AutenticacaoController : BaseController<Usuario>
    {
        // GET: Autenticacao/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return View();
            }
        }

        // GET: Autenticacao/RegistrarCliente
        public ActionResult RegistrarCliente()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrarCliente(CadastroCliente cadastroCliente)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return View();
            }
        }

        // GET: Autenticacao/RegistrarFornecedor
        public ActionResult RegistrarFornecedor()
        {
            TempData["Cidade"] = Helpers.GetSelectList("Cidades") as SelectList;
            TempData["Estado"] = Helpers.GetSelectList("Estados") as SelectList;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarFornecedor(CadastroFornecedor cadastroFornecedor)
        {
            if (ModelState.IsValid)
            {
                ResponseViewModel<Usuario> responseViewModel = new ResponseViewModel<Usuario>();
                Task.Run(async () => {
                    ResponseViewModel<Usuario> returnResponse = await AddObject(cadastroFornecedor, "Estacionamentos/CadastrarFornecedor");
                    responseViewModel = returnResponse;
                }).Wait();
               
                if(responseViewModel.Sucesso)
                    return RedirectToAction("Login");
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}