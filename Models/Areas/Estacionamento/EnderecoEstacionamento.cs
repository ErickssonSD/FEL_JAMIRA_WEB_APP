using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEL_JAMIRA_WEB_APP.Models.Areas.Estacionamento
{
    public class EnderecoEstacionamento
    {
        [Required(ErrorMessage = "O campo rua é obrigatório")]
        [Display(Name = "Rua:")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "O campo número é obrigatório")]
        [Display(Name = "Número:")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "O campo bairro é obrigatório")]
        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O campo cep é obrigatório")]
        [Display(Name = "CEP:")]
        public string CEP { get; set; }
        [Display(Name = "Detalhes:")]
        public string Complemento { get; set; }
        [Required(ErrorMessage = "O campo cidade é obrigatório")]
        [Display(Name = "Cidade:")]
        public int IdCidade { get; set; }
        [Required(ErrorMessage = "O campo estado é obrigatório")]
        [Display(Name = "Estado:")]
        public int IdEstado { get; set; }
    }
}