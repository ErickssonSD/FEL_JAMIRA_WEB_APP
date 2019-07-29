using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FEL_JAMIRA_WEB_APP.Models.Areas.Util
{
    public class Token
    {
        public string TokenData { get; set; }

        public string UserCode { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public string DocCode { get; set; }

    }
}