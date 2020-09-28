using GESCOM.Models.entidade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GESCOM
{
    public partial class ComissaoLista : System.Web.UI.Page
    {
        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            carregarGrid();
        }
        public void gvComissao_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = "Código";
                e.Row.Cells[1].Text = "Segurado";
                e.Row.Cells[2].Text = "Ramo";
                e.Row.Cells[3].Text = "Valor Liquido";
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Models.entidade.recibo_comissao_tb obj = ((Models.entidade.recibo_comissao_tb)e.Row.DataItem);

                //e.Row.Cells[0].Text = obj.recibo_comissao_id.ToString();
                //e.Row.Cells[1].Text = obj.proposta_tb.cotacao_tb.segurado_tb.pessoa_tb.nome;
                //e.Row.Cells[2].Text = obj.proposta_tb.cotacao_tb.ramo_tb.descricao;
                //e.Row.Cells[5].Text = obj.valor_liquido.ToString();

                //((HyperLink)e.Row.FindControl("lnkEditar")).NavigateUrl = string.Concat("PropostaDetalhe?id=", obj.recibo_comissao_id);
                //((HyperLink)e.Row.FindControl("lnkEditar")).Text = obj.recibo_comissao_id.ToString();
            }
        }


        

        #endregion

        #region eventos
        public void carregarGrid()
        {
            var lista = new ListaComissaoRepositorio().Listar();

            DataTable dt = new DataTable();
            dt.Columns.Add();

            dt.Columns.Add("Código");
            dt.Columns.Add("Segurado");
            dt.Columns.Add("Ramo");
            dt.Columns.Add("Valor Liquido");

            foreach(recibo_comissao_tb comissao in lista)
            {
                dt.Rows.Add(comissao.recibo_comissao_id.ToString()
                           ,comissao.proposta_tb.cotacao_tb.segurado_tb.pessoa_tb.nome
                           , comissao.proposta_tb.cotacao_tb.ramo_tb.descricao
                           , comissao.valor_liquido.ToString());
            }

            //gvComissao.DataSource = lista.ToList();
            gvComissao.DataSource = dt;
            gvComissao.DataBind();

        }

        #endregion
    }
}