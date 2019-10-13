using FEL_JAMIRA_WEB_APP.Models.Areas.Cliente;
using FEL_JAMIRA_WEB_APP.Models.Areas.Modelagem_do_Sistema;
using FEL_JAMIRA_WEB_APP.Models.Areas.MultiModelação;
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
            ViewBag.Cidade = Helpers.GetSelectList("Cidades", null) as SelectList;
            ViewBag.Estado = Helpers.GetSelectList("Estados", null) as SelectList;

            Cliente retorno = new Cliente();
            var task = Task.Run(async () => {

                using (BaseController<Cliente> bUsuario = new BaseController<Cliente>())
                {
                    var valorRetorno = await bUsuario.GetObjectAsyncWithToken("Clientes/BuscarCliente/" + GetIdPessoa(), await GetToken());
                    retorno = valorRetorno.Data;
                }
            });

            task.Wait();
            DadosCliente dadosCliente = new DadosCliente {
                Nome = retorno.Nome,
                Bairro = retorno.EnderecoPessoa.Bairro,
                CEP = retorno.EnderecoPessoa.CEP,
                Complemento = retorno.EnderecoPessoa.Complemento,
                CPF = retorno.CPF,
                Email = this.GetEmail(),
                IdCidade = retorno.EnderecoPessoa.IdCidade,
                IdEstado = retorno.EnderecoPessoa.IdEstado,
                Nascimento = retorno.Nascimento,
                Nickname = retorno.Nickname,
                Numero = retorno.EnderecoPessoa.Numero,
                RG = retorno.RG,
                Rua = retorno.EnderecoPessoa.Rua
            };

            ViewBag.Cadastrar = "Você precisa cadastrar um carro. clique aqui.";
            ViewBag.Nickname = retorno.Nome;
            ViewBag.InsereAlerta = !retorno.TemCarro;
            ViewBag.InsereAlerta2 = false;
            ViewBag.InsereAlerta3 = true;
            ViewBag.Level = 2;

            return View(dadosCliente);
        }

        [HttpGet]
        public ActionResult Carro()
        {
            CarroCliente carroCliente = new CarroCliente();
            ViewBag.Status = "";
            CarroRetorno retorno = new CarroRetorno();
            var task = Task.Run(async () => {
                token_ = await GetToken();

                using (BaseController<CarroRetorno> bCarro = new BaseController<CarroRetorno>())
                {
                    var valorRetorno = await bCarro.GetObjectAsyncWithToken("Carros/BuscarCarroCliente/" + GetIdPessoa(), token_);
                    retorno = valorRetorno.Data;
                }
            });
            task.Wait();

            if (retorno != null && retorno.IdMarca > 0)
            {
                carroCliente = new CarroCliente
                {
                    IdMarca = retorno.IdMarca,
                    Modelo = retorno.Modelo,
                    Placa = retorno.Placa,
                    Porte = retorno.Porte
                };
                ViewBag.Status = "Atualizar";
            }
            else
            {
                ViewBag.Status = "Cadastrar";
            }
            ViewBag.Nickname = retorno.Nome;
            ViewBag.InsereAlerta = retorno.Alerta;
            ViewBag.InsereAlerta2 = false;
            ViewBag.InsereAlerta3 = false;
            ViewBag.Level = retorno.Level;
            
            ViewBag.Marcas =  Helpers.GetSelectList("Marcas", token_) as SelectList;
            return View(carroCliente);
        }

        [HttpPost]
        public JsonResult RegistrarCarro(CarroCliente carroCliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ResponseViewModel<CarroCliente> responseViewModel = new ResponseViewModel<CarroCliente>();
                    carroCliente.IdCliente = GetIdPessoa();
                    var task = Task.Run(async () => {
                        using (BaseController<CarroCliente> baseController = new BaseController<CarroCliente>())
                        {
                            var retorno = await baseController.PostWithToken(carroCliente, "Carros/Registrar", await GetToken());
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

        public ActionResult Creditos()
        {
            Cliente retorno = new Cliente();
            var task = Task.Run(async () => {

                using (BaseController<Cliente> bUsuario = new BaseController<Cliente>())
                {
                    var valorRetorno = await bUsuario.GetObjectAsyncWithToken("Clientes/BuscarCliente/" + GetIdPessoa(), await GetToken());
                    retorno = valorRetorno.Data;
                }
            });
            task.Wait();

            ViewBag.Cadastrar = "Você precisa cadastrar um carro. clique aqui.";
            ViewBag.Nickname = retorno.Nome;
            ViewBag.InsereAlerta = !retorno.TemCarro;
            ViewBag.InsereAlerta2 = false;
            ViewBag.InsereAlerta3 = false;
            ViewBag.Level = 2;

            return View();
        }

        public ActionResult Solicitacoes()
        {
            Cliente retorno = new Cliente();
            var task = Task.Run(async () => {

                using (BaseController<Cliente> bUsuario = new BaseController<Cliente>())
                {
                    var valorRetorno = await bUsuario.GetObjectAsyncWithToken("Clientes/BuscarCliente/" + GetIdPessoa(), await GetToken());
                    retorno = valorRetorno.Data;
                }
            });
            task.Wait();

            ViewBag.Cadastrar = "Você precisa cadastrar um carro. clique aqui.";
            ViewBag.Nickname = retorno.Nome;
            ViewBag.InsereAlerta = !retorno.TemCarro;
            ViewBag.InsereAlerta2 = false;
            ViewBag.InsereAlerta3 = false;
            ViewBag.Level = 2;

            return View();
        }
    }
}