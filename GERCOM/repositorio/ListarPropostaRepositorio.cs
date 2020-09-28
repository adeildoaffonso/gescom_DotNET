using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESCOM
{
    public class ListarPropostaRepositorio
    {
        public List<proposta_tb> listar()
        {
            CTX_GERCOM ctx = new CTX_GERCOM();
            return ctx.proposta_tb.ToList();
        }
    }
}