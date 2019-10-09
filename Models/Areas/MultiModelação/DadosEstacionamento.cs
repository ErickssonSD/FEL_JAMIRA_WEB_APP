using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEL_JAMIRA_WEB_APP.Models.Areas.MultiModelação
{
    public class DadosEstacionamento
    {
        [Required(ErrorMessage = "O campo nome do estabelecimento é obrigatório")]
        [Display(Name = "Nome do Proprietario:")]
        public string NomeProprietario { get; set; }
        [Required(ErrorMessage = "O campo nome do estabelecimento é obrigatório")]
        [Display(Name = "Nome do Estabelecimento:")]
        public string NomeEstacionamento { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento do Proprietário:")]
        public DateTime? Nascimento { get; set; }
        //[CustomValidationCPF(ErrorMessage = "CPF inválido")]
        [Display(Name = "CPF do Proprietário:")]
        public string CPF { get; set; }
        [Display(Name = "RG do Proprietário:")]
        public string RG { get; set; }
        [Display(Name = "Valor por Hora:")]
        public int ValorHora { get; set; }
        [Required(ErrorMessage = "O campo apelido é obrigatório:")]
        [Display(Name = "Apelido:")]
        public string Nickname { get; set; }
        [Display(Name = "CNPJ:")]
        public string CNPJ { get; set; }
        [Display(Name = "Inscrição Estadual:")]
        public string InscricaoEstadual { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "O Email inserido não é válido.")]
        [Required(ErrorMessage = "O campo de email é obrigatório")]
        [Display(Name = "E-Mail:")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo de senha é obrigatório.")]
        [Display(Name = "Senha:")]
        public string Senha { get; set; }
        [Display(Name = "Confirmar a senha:")]
        [Compare("Senha", ErrorMessage = "A senha e a confirmação da senha são diferentes")]
        public string ConfirmaSenha { get; set; }
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
        [Display(Name = "Detalhes:")]
        public string Complemento { get; set; }
        [Display(Name = "Cidade:")]
        public int IdCidade { get; set; }
        [Display(Name = "Estado:")]
        public int IdEstado { get; set; }

        //Endereço do Estabelecimento

        [Display(Name = "Rua:")]
        public string RuaEstacionamento { get; set; }
        [Display(Name = "Número:")]
        public int? NumeroEstacionamento { get; set; }
        [Display(Name = "Bairro:")]
        public string BairroEstacionamento { get; set; }
        [Display(Name = "CEP:")]
        public string CEPEstacionamento { get; set; }
        [Display(Name = "Detalhes:")]
        public string ComplementoEstacionamento { get; set; }
        [Display(Name = "Cidade:")]
        public int? IdCidadeEstacionamento { get; set; }
        [Display(Name = "Estado:")]
        public int? IdEstadoEstacionamento { get; set; }

    }
}