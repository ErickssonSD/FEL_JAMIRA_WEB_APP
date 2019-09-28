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
        List<TransacoesDoCliente> transacoesDoClientes;
        List<EstacionamentosDoCliente> estacionamentosDoClientes;
        List<Recebimentos> recebimentos;
        List<UsuariosDoEstacionamento> usuariosDoEstacionamento;
        public ActionResult Index() {

            return RedirectToAction("Estacionamento");
        }

        public ActionResult FaleConosco()
        {
            return View();
        }

        // GET: Cliente
        //[Authorize]
        public ActionResult Cliente()
        {
            GetUsuario();
            //Transações do Cliente e Estacionamentos do Cliente
            Cliente cliente = new Cliente();
            var task = Task.Run(async () => {
                using (BaseController<Cliente> bUsuario = new BaseController<Cliente>())
                {

                    var valorRetorno = await bUsuario.GetObjectAsync("Clientes/Detalhes/" + _usuario.IdPessoa);
                    cliente = valorRetorno.Data;
                }

                using (BaseController<List<TransacoesDoCliente>> bUsuario = new BaseController<List<TransacoesDoCliente>>())
                {

                    var valorRetorno = await bUsuario.GetObjectAsync("CompraCreditos/GetTransacoesDoCliente?idUsuario=" + _usuario.IdPessoa);
                    transacoesDoClientes = valorRetorno.Data;
                }

                using (BaseController<List<EstacionamentosDoCliente>> bUsuario = new BaseController<List<EstacionamentosDoCliente>>())
                {

                    var valorRetorno = await bUsuario.GetObjectAsync("Solicitacao/GetEstacionamentosDoCliente?idUsuario=" + _usuario.IdPessoa);
                    estacionamentosDoClientes = valorRetorno.Data;
                }
            });
            task.Wait();
            ViewBag.Transacoes = transacoesDoClientes.Take(5).OrderByDescending(x => x.DataTransacao).ToList();
            ViewBag.Estacionamentos = estacionamentosDoClientes.Take(5).OrderByDescending(x => x.PeriodoDe);
            ViewBag.InsereAlerta = !cliente.TemCarro;
            ViewBag.Nickname = cliente.Nome;
            ViewBag.Cadastrar = "Você precisa cadastrar um carro. clique aqui.";
            ViewBag.Level = 2;

            return View();
        }

        // GET: Estacionamento
        //[Authorize]
        public ActionResult Estacionamento()
        {
            GetUsuario();
            //Recebimentos e Usuarios do Estacionamento
            Estacionamento estacionamento = new Estacionamento();
            var task = Task.Run(async () => {

                using (BaseController<Estacionamento> bUsuario = new BaseController<Estacionamento>())
                {

                    var valorRetorno = await bUsuario.GetObjectAsync("Estacionamentos/EstacionamentoPorPessoa?IdPessoa=" + _usuario.IdPessoa);
                    estacionamento = valorRetorno.Data;
                }

                using (BaseController<List<TransacoesDoCliente>> bUsuario = new BaseController<List<TransacoesDoCliente>>())
                {

                    var valorRetorno = await bUsuario.GetObjectAsync("Solicitacao/GetRecebimentos?idUsuario=" + _usuario.IdPessoa);
                    transacoesDoClientes = valorRetorno.Data;
                }

                using (BaseController<List<EstacionamentosDoCliente>> bUsuario = new BaseController<List<EstacionamentosDoCliente>>())
                {

                    var valorRetorno = await bUsuario.GetObjectAsync("Solicitacao/GetUsuariosDoEstacionamento?idUsuario=" + _usuario.IdPessoa);
                    estacionamentosDoClientes = valorRetorno.Data;
                }
            });
            task.Wait();
            ViewBag.Recebimentos = recebimentos?.Take(5).OrderByDescending(x => x.Date).ToList();
            ViewBag.Usuarios = usuariosDoEstacionamento?.Take(5).OrderByDescending(x => x.PeriodoDe).ToList();
            ViewBag.InsereAlerta = !estacionamento.TemEstacionamento;
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