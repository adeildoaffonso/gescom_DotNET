using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;

namespace GESCOM
{
    public partial class SeguradoraLista : System.Web.UI.Page
    {
        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            carregarGrid();
        }

        public void gvSeguradora_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                seguradora_tb obj = ((seguradora_tb)e.Row.DataItem);

                ((HyperLink)e.Row.FindControl("lnkEditar")).NavigateUrl = string.Concat("SeguradoraDetalhe?id=", obj.seguradora_id);
                ((HyperLink)e.Row.FindControl("lnkEditar")).Text = obj.seguradora_id.ToString();
            }
        }
        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguradoraDetalhe.aspx");
        }

        #endregion

        #region metodos        
        public void carregarGrid()
        {
            var lista = new ListaSeguradoraRepositorio().Listar();

            if (lista == null) return;

            gvSeguradora.DataSource = lista.ToList();
            gvSeguradora.DataBind();
        }
        #endregion

    }
}