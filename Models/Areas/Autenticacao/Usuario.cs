using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEL_JAMIRA_WEB_APP.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "O Email inserido não é válido.")]
        [Required(ErrorMessage = "O campo de login é obrigatório")]
        public string Login { get; set; }
        [Required(ErrorMessage = "O campo de senha é obrigatório.")]
        public string Senha { get; set; }
        public string AuxSenha { get; set; }
        public int Level { get; set; }
    }
}