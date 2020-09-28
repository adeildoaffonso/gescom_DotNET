using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GESCOM
{
    public partial class PropostaLista : System.Web.UI.Page
    {
        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            carregarGrid();
        }
        public void gvProposta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                proposta_tb obj = ((proposta_tb)e.Row.DataItem);

                ((HyperLink)e.Row.FindControl("lnkEditar")).NavigateUrl = string.Concat("PropostaDetalhe?id=", obj.proposta_id);
                ((HyperLink)e.Row.FindControl("lnkEditar")).Text = obj.proposta_id.ToString();
            }
        }

        #endregion

        #region Métodos
        public void carregarGrid()
        {
            var lista = new ListarPropostaRepositorio().listar();
            gvProposta.DataSource = lista.ToList();
            gvProposta.DataBind();
        }
        #endregion
    }
}