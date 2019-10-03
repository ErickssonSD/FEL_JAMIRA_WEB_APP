﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEL_JAMIRA_WEB_APP.Models.Areas.MultiModelação
{
    public class DadosCliente
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [Display(Name = "Nome Completo:")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo apelido é obrigatório")]
        [Display(Name = "Apelido:")]
        public string Nickname { get; set; }
        //[CustomValidationCPF(ErrorMessage = "CPF inválido")]
        [Display(Name = "CPF:")]
        public string CPF { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento:")]
        public DateTime? Nascimento { get; set; }
        [Display(Name = "RG:")]
        public string RG { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "O Email inserido não é válido.")]
        [Required(ErrorMessage = "O campo de email é obrigatório")]
        [Display(Name = "E-Mail:")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo rua é obrigatório")]
        [Display(Name = "Rua:")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "O campo número é obrigatório")]
        [Display(Name = "Número:")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "O campo bairro é obrigatório")]
        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }
        [Display(Name = "CEP:")]
        public string CEP { get; set; }
        [Display(Name = "Complemento:")]
        public string Complemento { get; set; }
        [Display(Name = "Cidade:")]
        public int IdCidade { get; set; }
        [Display(Name = "Estado:")]
        public int IdEstado { get; set; }
    }
}