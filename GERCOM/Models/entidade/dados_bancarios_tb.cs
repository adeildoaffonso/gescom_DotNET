using GESCOM.Models.entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GESCOM
{
    public class dados_bancarios_tb
    {
        [Key]
        public int dados_bancarios_id { get; set; }
        public int codigo_banco { get; set; }
        public int codigo_agencia { get; set; }
        public int conta_corrente { get; set; }
        public int pessoa_id { get; set; }
        public virtual pessoa_tb pessoa_tb { get; set; }
    }
}
 