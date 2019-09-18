using FEL_JAMIRA_WEB_APP.Models;
using FEL_JAMIRA_WEB_APP.Models.Areas.Cliente;
using FEL_JAMIRA_WEB_APP.Models.Areas.Estacionamento;
using FEL_JAMIRA_WEB_APP.Models.Areas.Util;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace FEL_JAMIRA_WEB_APP.Controllers
{
    //[RequireHttps]
    //[SessionExpire]
    //[SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class BaseController<T> : Controller
    {

        string    URI = System.Configuration.ConfigurationManager.AppSettings["UrlWebAPI"]; 
        string    UrlParm = System.Configuration.ConfigurationManager.AppSettings["UrlParameter"];
        protected string idCookie;
        protected Usuario _usuario;

        HttpClient client = new HttpClient();
        public async Task<ResponseViewModel<T>> GetObjectAsync(string complemento)
        {
            try
            {
                string url = URI + complemento;
                var response = await client.GetStringAsync(url);
                var objectReturn = JsonConvert.DeserializeObject<ResponseViewModel<T>>(response);
                return objectReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ResponseViewModel<T>> PostObject(object oParametro, string complemento)
        {
            try
            {
                string url = URI + complemento;
                var data = JsonConvert.SerializeObject(oParametro);
                ResponseViewModel<T> responseViewModel = new ResponseViewModel<T>();

                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("Connection", "keep-alive");
                request.AddHeader("Content-Length", data.Length.ToString());
                request.AddHeader("Accept-Encoding", "gzip, deflate");
                request.AddHeader("Host", UrlParm);
                request.AddHeader("Cache-Control", "no-cache");
                request.AddHeader("Accept", "*/*");
                request.AddHeader("Content-Type", "application/json");
                request.AddParameter("undefined", data, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                responseViewModel = new JavaScriptSerializer().Deserialize<ResponseViewModel<T>>(response.Content);
                return responseViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GetUsuario()
        {
            if (Request.Cookies["authCookie"] != null)
            {
                var decTicket = FormsAuthentication.Decrypt(Request.Cookies["authCookie"].Value);
                var idUsuario = decTicket.Name.Split('-');
                SetarUsuarioLogado(idUsuario[0]);
            }
            else
                RedirectToAction("Login", "Autenticacao");
        }

        public int GetIdUsuario()
        {
            if (Request.Cookies["authCookie"] != null)
            {
                var decTicket = FormsAuthentication.Decrypt(Request.Cookies["authCookie"].Value);
                var idPessoa = decTicket.Name.Split('-');
                return int.Parse(idPessoa[1]);
            }
            else
                return 0;
        }
        public void SetarUsuarioLogado(string id)
        {
            var task = Task.Run(async () => {
                using (BaseController<Usuario> bUsuario = new BaseController<Usuario>())
                { 
                    var valorRetorno = await bUsuario.GetObjectAsync("Usuarios/Detalhes/" + id);
                    _usuario = valorRetorno.Data;
                }
            });
            task.Wait();
        }
        public async Task DeletaProdutoAsync(object produto, string complemento)
        {
            //string url = "http://www.macwebapi.somee.com/api/produtos/{0}";
            string url = URI + complemento;
            var uri = new Uri(string.Format(url));
            await client.DeleteAsync(uri);
        }
        public void DesconectarUsuario()
        {
            Util.Util.DesconectarUsuario();
            Dispose();
            RedirectToAction("Login","Autenticacao");
        }
    }
}
