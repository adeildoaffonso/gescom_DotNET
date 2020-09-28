using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESCOM.Models.entidade
{
    public class Pessoa
    {
        public int PessoaID { get; set; }
        public string Nome { get; set; }
        public string cpf_cnpj { get; set; }
        public int Tipo_Pessoa { get; set; }
    }
}