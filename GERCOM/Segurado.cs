using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESCOM
{
    public class Segurado
    {
        public segurado_tb RecuperarPelaChave(int chave)
        {
            CTX_GERCOM ctx = new CTX_GERCOM();
            return ctx.segurado_tb.Include("pessoa_tb").Where(c => c.segurado_id == chave).FirstOrDefault();
        }

        public segurado_tb RecuperarPelaChave(CTX_GERCOM ctx, int chave)
        {
            return ctx.segurado_tb.Include("pessoa_tb").Where(c => c.segurado_id == chave).FirstOrDefault();
        }
    }
}