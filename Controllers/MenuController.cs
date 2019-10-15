using FEL_JAMIRA_WEB_APP.Models;
using FEL_JAMIRA_WEB_APP.Models.Areas.Cliente;
using FEL_JAMIRA_WEB_APP.Models.Areas.Estacionamento;
using FEL_JAMIRA_WEB_APP.Models.Areas.Modelagem_do_Sistema;
using FEL_JAMIRA_WEB_APP.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FEL_JAMIRA_WEB_APP.Controllers
{
    public class MenuController : BaseController<Usuario>
    {
        public ActionResult FaleConosco()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaleConosco(FaleConosco faleConosco)
        {
            FaleConosco retorno = new FaleConosco();
            var task = Task.Run(async () => {
                using (BaseController<FaleConosco> bUsuario = new BaseController<FaleConosco>())
                {
                    var valorRetorno = await bUsuario.PostWithToken(faleConosco, "FaleConosco/Cadastrar", await GetToken());
                    retorno = valorRetorno.Data;
                }
            });
            return View();
        }


        // GET: Cliente
        //[Authorize]
        public ActionResult Cliente()
        {
            var task1 = Task.Run(async () => {
                this.token_ = await GetToken();
            });
            task1.Wait();

            GetUsuario();

            List<TransacoesDoCliente> transacoesDoClientes = new List<TransacoesDoCliente>();
            List<EstacionamentosDoCliente> estacionamentosDoClientes = new List<EstacionamentosDoCliente>();
            //Transações do Cliente e Estacionamentos do Cliente
            Cliente cliente = new Cliente();
            var task = Task.Run(async () => {
                using (BaseController<Cliente> bUsuario = new BaseController<Cliente>())
                {

                    var valorRetorno = await bUsuario.GetObjectAsyncWithToken("Clientes/Detalhes/" + _usuario.IdPessoa, token_);
                    cliente = valorRetorno.Data;
                }

                using (BaseController<List<TransacoesDoCliente>> bUsuario = new BaseController<List<TransacoesDoCliente>>())
                {

                    var valorRetorno = await bUsuario.GetObjectAsyncWithToken("CompraCreditos/GetTransacoesDoCliente?idUsuario=" + _usuario.IdPessoa, token_);
                    transacoesDoClientes = valorRetorno.Data;
                }

                using (BaseController<List<EstacionamentosDoCliente>> bUsuario = new BaseController<List<EstacionamentosDoCliente>>())
                {

                    var valorRetorno = await bUsuario.GetObjectAsyncWithToken("Solicitacao/GetEstacionamentosDoCliente?idUsuario=" + _usuario.IdPessoa, token_);
                    estacionamentosDoClientes = valorRetorno.Data;
                }
            });
            task.Wait();
            ViewBag.Transacoes = transacoesDoClientes.OrderByDescending(x => x.DataTransacao).ToList() as List<TransacoesDoCliente>;
            ViewBag.Estacionamentos = estacionamentosDoClientes.OrderByDescending(x => x.PeriodoDe).ToList() as List<EstacionamentosDoCliente>;
            ViewBag.InsereAlerta = !cliente.TemCarro;
            ViewBag.InsereAlerta2 = false;
            ViewBag.InsereAlerta3 = false;
            ViewBag.Nickname = cliente.Nome;
            ViewBag.Cadastrar = "Você precisa cadastrar um carro. clique aqui.";
            ViewBag.Saldo = string.Format("{0:N}", cliente.Saldo);
            ViewBag.Level = 2;

            return View();
        }

        // GET: Estacionamento
        //[Authorize]
        public ActionResult Estacionamento()
        {
            var task1 = Task.Run(async () => {
                this.token_ = await GetToken();
            });
            task1.Wait();

            GetUsuario();
            List<Recebimentos> recebimentos = new List<Recebimentos>();
            List<RecebimentosFiltrados> recebimentosFiltrados = new List<RecebimentosFiltrados>();
            List<UsuariosDoEstacionamento> usuariosDoEstacionamento = new List<UsuariosDoEstacionamento>();
            List<Solicitantes> solicitacoes = new List<Solicitantes>();
            List<Solicitantes> solicitacoes2 = new List<Solicitantes>();

            //Recebimentos e Usuarios do Estacionamento
            Estacionamento estacionamento = new Estacionamento();
            var task = Task.Run(async () => {

                using (BaseController<Estacionamento> bUsuario = new BaseController<Estacionamento>())
                {

                    var valorRetorno = await bUsuario.GetObjectAsyncWithToken("Estacionamentos/EstacionamentoPorPessoa?IdPessoa=" + _usuario.IdPessoa, token_);
                    estacionamento = valorRetorno.Data;
                }

                using (BaseController<List<Recebimentos>> bUsuario = new BaseController<List<Recebimentos>>())
                {

                    var valorRetorno = await bUsuario.GetObjectAsyncWithToken("Solicitacao/GetRecebimentos?idUsuario=" + _usuario.IdPessoa, token_);
                    recebimentos = valorRetorno.Data;
                }

                using (BaseController<List<UsuariosDoEstacionamento>> bUsuario = new BaseController<List<UsuariosDoEstacionamento>>())
                {

                    var valorRetorno = await bUsuario.GetObjectAsyncWithToken("Solicitacao/GetUsuariosDoEstacionamento?idUsuario=" + estacionamento.Id, token_);
                    usuariosDoEstacionamento = valorRetorno.Data;
                }

                using (BaseController<List<Solicitantes>> bUsuario = new BaseController<List<Solicitantes>>())
                {
                    var valorRetorno = await bUsuario.GetObjectAsyncWithToken("Solicitacao/GetSolicitacoesEmAberto?idUsuario=" + GetIdPessoa(), await GetToken());
                    solicitacoes = valorRetorno.Data;
                }

                using (BaseController<List<Solicitantes>> bUsuario = new BaseController<List<Solicitantes>>())
                {
                    var valorRetorno = await bUsuario.GetObjectAsyncWithToken("Solicitacao/GetSolicitacoesParaFinalizar?idUsuario=" + GetIdPessoa(), await GetToken());
                    solicitacoes2 = valorRetorno.Data;
                }
            });
            task.Wait();
            foreach (var item in recebimentos)
            {
                var it = item.MesAno.Split('-');
                RecebimentosFiltrados recebimentos1 = new RecebimentosFiltrados();
                recebimentos1.Mes = int.Parse(it[0]);
                recebimentos1.Ano = int.Parse(it[1]);
                recebimentos1.MesAno = recebimentos1.Mes + recebimentos1.Ano;
                recebimentos1.Valor = item.Valor;
                recebimentosFiltrados.Add(recebimentos1);
            }
            ViewBag.Recebimentos = recebimentosFiltrados?.OrderByDescending(x => x.MesAno).ToList() as List<RecebimentosFiltrados>;
            ViewBag.Usuarios = usuariosDoEstacionamento?.OrderByDescending(x => x.PeriodoDe).ToList() as List<UsuariosDoEstacionamento>;
            ViewBag.InsereAlerta = !estacionamento.TemEstacionamento;
            ViewBag.InsereAlerta2 = solicitacoes.Count > 0 && solicitacoes.First().NomeCliente != null ? true : false;
            ViewBag.InsereAlerta3 = solicitacoes2.Count > 0 && solicitacoes2.First().NomeCliente != null ? true : false;
            ViewBag.Nickname = estacionamento.Proprietario.Nome;
            ViewBag.Cadastrar = "Você precisa cadastrar um endereco para seu estacionamento. clique aqui.";
            ViewBag.Level = 1;
            return View();
        }

        public ActionResult MeusDados()
        {
            int meuLevel = GetLevel();
            if (meuLevel.Equals(1))
                return RedirectToAction("MeusDados", "Estacionamento");
            else if (meuLevel.Equals(2))
                return RedirectToAction("MeusDados", "Cliente");
            else
                return RedirectToAction("Login", "Autenticacao");
        }

        public ActionResult DirecionalMenu()
        {
            int meuLevel = GetLevel();
            if (meuLevel.Equals(1))
                return RedirectToAction("Estacionamento");
            else if (meuLevel.Equals(2))
                return RedirectToAction("Cliente");
            else
                return RedirectToAction("Login", "Autenticacao");
        }

        public ActionResult DirecionalCadastro()
        {
            int meuLevel = GetLevel();
            if (meuLevel.Equals(1))
                return RedirectToAction("Endereco", "Estacionamento");
            else if(meuLevel.Equals(2))
                return RedirectToAction("Carro", "Cliente");
            else
                return RedirectToAction("Login", "Autenticacao");
        }

    }
}