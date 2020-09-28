using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESCOM
{
    public class ListaPropostaParcelaRepositorio
    {
        public List<proposta_parcela_tb> listar()
        {
            CTX_GERCOM ctx = new CTX_GERCOM();
            return ctx.proposta_parcela_tb.ToList();
        }
    }
}