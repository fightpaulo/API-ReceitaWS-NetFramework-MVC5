using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReceitaWS.Models.Entities
{
    public class AtividadeSecundaria
    {
        public string Text { get; set; }
        public string Code { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}