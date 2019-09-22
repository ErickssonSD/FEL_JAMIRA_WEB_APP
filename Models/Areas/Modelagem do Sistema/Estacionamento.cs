using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEL_JAMIRA_WEB_APP.Models.Areas.Modelagem_do_Sistema
{
    public class Estacionamento : Pessoa
    {
        public int IdEstacionamento { get; set; }
        public string NomeEstacionamento { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public bool TemEstacionamento { get; set; }
        public int? IdEnderecoEstabelecimento { get; set; }
        public Pessoa Proprietario { get; set; }
    }
}