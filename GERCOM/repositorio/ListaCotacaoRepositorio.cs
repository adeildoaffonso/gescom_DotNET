using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESCOM
{
    public class ListaCotacaoRepositorio
    {
        public List<cotacao_tb> listar()
        {
            CTX_GERCOM ctx = new CTX_GERCOM();
            return ctx.cotacao_tb.Include("segurado_tb").ToList();
        }
    }
}