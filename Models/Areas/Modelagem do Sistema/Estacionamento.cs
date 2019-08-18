using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEL_JAMIRA_WEB_APP.Models.Areas.Modelagem_do_Sistema
{
    public class Estacionamento
    {
        public int IdEstacionamento { get; set; }
        [Required(ErrorMessage = "Nome do Estacionamento é Obrigatório")]
        public string NomeEstacionamento { get; set; }
        [Required(ErrorMessage = "Nome do Estacionamento é Obrigatório")]
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public int? IdEnderecoEstabelecimento { get; set; }
    }
}