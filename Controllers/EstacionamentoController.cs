using FEL_JAMIRA_WEB_APP.Models.Areas.Estacionamento;
using FEL_JAMIRA_WEB_APP.Models.Areas.Localizacao;
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
    public class EstacionamentoController : BaseController<Pessoa>
    {
        // GET: MeusDados
        public ActionResult MeusDados()
        {
            Estacionamento retorno = new Estacionamento();
            var task = Task.Run(async () => {

                using (BaseController<Estacionamento> bUsuario = new BaseController<Estacionamento>())
                {
                    var valorRetorno = await bUsuario.GetObjectAsyncWithToken("Estacionamentos/EstacionamentoPorPessoa?IdPessoa=" + GetIdPessoa(), await GetToken());
                    retorno = valorRetorno.Data;
                }
            });
            task.Wait();

            if (null == retorno.EnderecoEstacionamento)
            {
                retorno.EnderecoEstacionamento = new Endereco();
            }

            DadosEstacionamento dadosEstacionamento = new DadosEstacionamento {
                Bairro = retorno.EnderecoEstacionamento.Bairro,
                CEP = retorno.EnderecoEstacionamento.CEP,
                CNPJ = retorno.CNPJ,
                Complemento = retorno.EnderecoEstacionamento.Complemento,
                CPF = retorno.Proprietario.CPF,
                Email = GetEmail(),
                IdCidade = retorno.EnderecoEstacionamento.IdCidade,
                IdEstado = retorno.EnderecoEstacionamento.IdEstado,
                InscricaoEstadual = retorno.InscricaoEstadual,
                Nascimento = retorno.Proprietario.Nascimento,
                Nickname = retorno.Proprietario.Nome,
                NomeEstacionamento = retorno.NomeEstacionamento,
                NomeProprietario = retorno.Proprietario.Nome,
                Numero = retorno.EnderecoEstacionamento.Numero,
                RG = retorno.Proprietario.RG,
                Rua = retorno.EnderecoEstacionamento.Rua,
                BairroEstacionamento = retorno.Proprietario.EnderecoPessoa.Bairro,
                CEPEstacionamento = retorno.Proprietario.EnderecoPessoa.CEP,
                ComplementoEstacionamento = retorno.Proprietario.EnderecoPessoa.Complemento,
                IdCidadeEstacionamento = retorno.Proprietario.EnderecoPessoa.IdCidade,
                IdEstadoEstacionamento = retorno.Proprietario.EnderecoPessoa.IdEstado,
                NumeroEstacionamento = retorno.Proprietario.EnderecoPessoa.Numero,
                RuaEstacionamento = retorno.Proprietario.EnderecoPessoa.Rua
            };

            ViewBag.InsereAlerta = !retorno.TemEstacionamento;
            ViewBag.Nickname     = retorno.Proprietario.Nome;
            ViewBag.Cidade       = Helpers.GetSelectList("Cidades") as SelectList;
            ViewBag.Estado       = Helpers.GetSelectList("Estados") as SelectList;
            ViewBag.Level        = GetLevel();
            return View(dadosEstacionamento);
        }

        public async Task<JsonResult> GetRecebimentos()
        {
            BaseController<Recebimentos> baseController = new BaseController<Recebimentos>();
            ResponseViewModel<Recebimentos> retorno = new ResponseViewModel<Recebimentos>();
            int UsuarioLogado = GetIdPessoa();
            retorno = await baseController.PostObject(UsuarioLogado,"Estacionamentos/GetRecebimentos");
            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Endereco()
        {
            EnderecoEstacionamento enderecoEstacionamento = new EnderecoEstacionamento();
            ViewBag.Status = "";
            ViewBag.Cidade = Helpers.GetSelectList("Cidades") as SelectList;
            ViewBag.Estado = Helpers.GetSelectList("Estados") as SelectList;
            Estacionamento retorno = new Estacionamento();
            var task = Task.Run(async () => {

                using (BaseController<Estacionamento> bUsuario = new BaseController<Estacionamento>())
                {
                    var valorRetorno = await bUsuario.GetObjectAsyncWithToken("Estacionamentos/EstacionamentoPorPessoa?IdPessoa=" + GetIdPessoa(), await GetToken());
                    retorno = valorRetorno.Data;
                }
            });
            task.Wait();

            if (retorno.IdEnderecoEstabelecimento > 0)
            {
                enderecoEstacionamento = new EnderecoEstacionamento
                {
                    Bairro = retorno.EnderecoEstacionamento.Bairro,
                    CEP = retorno.EnderecoEstacionamento.CEP,
                    Complemento = retorno.EnderecoEstacionamento.Complemento,
                    IdCidade = retorno.EnderecoEstacionamento.IdCidade,
                    IdEstado = retorno.EnderecoEstacionamento.IdEstado,
                    Numero = retorno.EnderecoEstacionamento.Numero,
                    Rua = retorno.EnderecoEstacionamento.Rua
                };
                ViewBag.Status = "Atualizar";
            }
            else
            {
                ViewBag.Status = "Cadastrar";
            }

            ViewBag.Cadastrar = "Você precisa cadastrar um endereco para seu estacionamento. clique aqui.";
            ViewBag.Nickname = retorno.Proprietario.Nome;
            ViewBag.InsereAlerta = !retorno.TemEstacionamento;
            ViewBag.Level = 1;
            return View(enderecoEstacionamento);
        }

        [HttpPost]
        public JsonResult RegistrarEstacionamento(EnderecoEstacionamento enderecoEstacionamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ResponseViewModel<EnderecoEstacionamento> responseViewModel = new ResponseViewModel<EnderecoEstacionamento>();
                    enderecoEstacionamento.IdPessoa = GetIdPessoa();
                    var task = Task.Run(async () => {
                        using (BaseController<EnderecoEstacionamento> baseController = new BaseController<EnderecoEstacionamento>())
                        {
                            var retorno = await baseController.PostObject(enderecoEstacionamento, "Enderecos/Registrar");
                            responseViewModel = retorno;
                        }
                    });
                    task.Wait();
                    return Json(responseViewModel, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    ResponseViewModel<EnderecoEstacionamento> responseViewModel = new ResponseViewModel<EnderecoEstacionamento>
                    {
                        Data = enderecoEstacionamento,
                        Mensagem = "Dados inválidos.",
                        Serializado = true,
                        Sucesso = false
                    };

                    return Json(responseViewModel, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                ResponseViewModel<EnderecoEstacionamento> responseViewModel = new ResponseViewModel<EnderecoEstacionamento>
                {
                    Data = enderecoEstacionamento,
                    Mensagem = "Ocorreu um erro ao processar sua solicitação.",
                    Serializado = true,
                    Sucesso = false
                };

                return Json(responseViewModel, JsonRequestBehavior.AllowGet);
            }
        }
    }
}