using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESCOM
{
    public class SeguradoraRepositorio
    {
        public seguradora_tb RecuperarPelaChave(int chave)
        {
            CTX_GERCOM ctx = new CTX_GERCOM();
            return ctx.seguradora_tb.Include("pessoa_tb").Where(c => c.seguradora_id == chave).FirstOrDefault();
        }

        public seguradora_tb RecuperarPelaChave(CTX_GERCOM ctx, int chave)
        {
            return ctx.seguradora_tb.Include("pessoa_tb").Where(c => c.seguradora_id == chave).FirstOrDefault();
        }
    }
}