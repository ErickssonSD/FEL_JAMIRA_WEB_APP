using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FEL_JAMIRA_WEB_APP.Models.Areas.Modelagem_do_Sistema
{
    public class FaleConosco
    {
        public int IdPessoa { get; set; }
        public string Texto { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}