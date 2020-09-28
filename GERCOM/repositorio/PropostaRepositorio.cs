using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESCOM
{
    public class PropostaRepositorio
    { 
        public proposta_tb RecuperarPelaChave(int chave)
        {
            CTX_GERCOM ctx = new CTX_GERCOM();
            return ctx.proposta_tb.Where(c => c.proposta_id == chave).FirstOrDefault();
        }

        public proposta_tb RecuperarPelaChave(CTX_GERCOM ctx, int chave)
        {
            return ctx.proposta_tb.Include("cotacao_tb").Where(c => c.cotacao_id == chave).FirstOrDefault();
        }
    }
}