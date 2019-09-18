using FEL_JAMIRA_WEB_APP.Models.Areas.Cliente;
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
    public class ClienteController : BaseController<Pessoa>
    {
        // GET: MeusDados
        public ActionResult MeusDados()
        {
            ViewBag.Cidade = Helpers.GetSelectList("Cidades") as SelectList;
            ViewBag.Estado = Helpers.GetSelectList("Estados") as SelectList;
            return View();
        }

        [HttpGet]
        public ActionResult CadastrarCarro()
        {
            ViewBag.Marcas = Helpers.GetSelectList("Marcas") as SelectList;
            return PartialView("~/Views/Cliente/CadastrarCarro.cshtml");
        }

        [HttpPost]
        public JsonResult RegistrarCarro(CarroCliente carroCliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ResponseViewModel<CarroCliente> responseViewModel = new ResponseViewModel<CarroCliente>();
                    carroCliente.IdCliente = GetIdUsuario();
                    var task = Task.Run(async () => {
                        using (BaseController<CarroCliente> baseController = new BaseController<CarroCliente>())
                        {
                            var retorno = await baseController.PostObject(carroCliente, "Carros/Registrar");
                            responseViewModel = retorno;
                        }
                    });
                    task.Wait();
                    return Json(responseViewModel);
                }
                else
                {
                    ResponseViewModel<CarroCliente> responseViewModel = new ResponseViewModel<CarroCliente>
                    {
                        Data = carroCliente,
                        Mensagem = "Dados inválidos.",
                        Serializado = true,
                        Sucesso = false
                    };

                    return Json(responseViewModel, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                ResponseViewModel<CarroCliente> responseViewModel = new ResponseViewModel<CarroCliente>
                {
                    Data = carroCliente,
                    Mensagem = "Ocorreu um erro ao processar sua solicitação.",
                    Serializado = true,
                    Sucesso = false
                };

                return Json(responseViewModel, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}