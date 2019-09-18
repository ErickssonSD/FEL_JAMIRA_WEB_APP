using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FEL_JAMIRA_WEB_APP.Models.Areas.Cliente
{
    public class CarroCliente
    {
        [Required(ErrorMessage = "O campo placa é obrigatório")]
        public string Placa { get; set; }
        [Required(ErrorMessage = "O campo porte é obrigatório")]
        public string Porte { get; set; }
        [Required(ErrorMessage = "O campo modelo é obrigatório")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "O campo marca é obrigatório")]
        public int IdMarca { get; set; }
        public int IdCliente { get; set; }
    }
}