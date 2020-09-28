using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESCOM
{
    public class CotacaoRepositorio
    {
        public cotacao_tb RecuperarPelaChave(int chave)
        {
            CTX_GERCOM ctx = new CTX_GERCOM();
            return ctx.cotacao_tb.Where(c => c.cotacao_id == chave).FirstOrDefault();
        }

        public cotacao_tb RecuperarPelaChave(CTX_GERCOM ctx, int chave)
        {
             return ctx.cotacao_tb.Where(c => c.cotacao_id == chave).FirstOrDefault();
        }
    }
}