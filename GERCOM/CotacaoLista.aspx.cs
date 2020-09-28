using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GESCOM
{
    public partial class CotacaoLista : System.Web.UI.Page
    {

        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            /*CTX_GERCOM ctx = new CTX_GERCOM();
            var lista = from co in ctx.cotacao_tb
                        join seg in ctx.segurado_tb on co.segurado_id equals seg.segurado_id
                        join pe in ctx.pessoa_tb on seg.pessoa_id equals pe.pessoa_id
                        join ra in ctx.ramo_tb on co.ramo_id equals ra.ramo_id
                        select new { Codigo = co.codigo
                                     ,Segurado = pe.nome
                                     ,Ramo = ra.descricao
                                     ,Valor = co.valor
                                     ,Data = co.data_cotacao};

            gvCotacao.DataSource = lista.ToList();
            gvCotacao.DataBind();*/

            carregarGrid();
        }

        public void gvCotacao_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                cotacao_tb obj = ((cotacao_tb)e.Row.DataItem);

                ((HyperLink)e.Row.FindControl("lnkEditar")).NavigateUrl = string.Concat("CotacaoDetalhe?id=", obj.cotacao_id);
                ((HyperLink)e.Row.FindControl("lnkEditar")).Text = obj.codigo;
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CotacaoDetalhe.aspx");
        }
        #endregion

        #region métodos
        public void carregarGrid()
        {
            var lista = new ListaCotacaoRepositorio().listar();
            gvCotacao.DataSource = lista.ToList();
            gvCotacao.DataBind();
        }
        #endregion
    }
}