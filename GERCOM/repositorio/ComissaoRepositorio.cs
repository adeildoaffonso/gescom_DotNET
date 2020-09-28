using GESCOM.Models.entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GESCOM
{
    public class ComissaoRepositorio
    {
        public Models.entidade.recibo_comissao_tb RecuperarPelaChave(int chave)
        {
            CTX_GERCOM ctx = new CTX_GERCOM();
            return ctx.recibo_comissao_tb.Include("recibo_comissao_tb").Include("corretor_tb").Include("pessoa_tb").Where(c => c.recibo_comissao_id == chave).FirstOrDefault();
        }

        public Models.entidade.recibo_comissao_tb RecuperarPelaChave(CTX_GERCOM ctx, int chave)
        {
            return ctx.recibo_comissao_tb.Include("recibo_comissao_tb").Include("corretor_tb").Include("pessoa_tb").Where(c => c.recibo_comissao_id == chave).FirstOrDefault();
        }

        public Models.entidade.recibo_comissao_tb RecuperarPelaProposta(int propostaID)
        {
            CTX_GERCOM ctx = new CTX_GERCOM();
            return ctx.recibo_comissao_tb.Include("recibo_comissao_tb").Include("corretor_tb").Include("pessoa_tb").Where(c => c.proposta_id == propostaID).FirstOrDefault();
        }

        public Models.entidade.recibo_comissao_tb RecuperarPelaProposta(CTX_GERCOM ctx, int propostaID)
        {
            return ctx.recibo_comissao_tb.Include("recibo_comissao_tb").Include("corretor_tb").Include("pessoa_tb").Where(c => c.proposta_id == propostaID).FirstOrDefault();
        }
    }
}