using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GESCOM
{
    public partial class ClienteLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            carregarGrid();
        }
        public void gvSegurado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                segurado_tb obj = ((segurado_tb)e.Row.DataItem);

                ((HyperLink)e.Row.FindControl("lnkEditar")).NavigateUrl = string.Concat("SeguradoDetalhe?id=", obj.segurado_id);
                ((HyperLink)e.Row.FindControl("lnkEditar")).Text = obj.segurado_id.ToString();
            }
        }

        public void carregarGrid()
        {
            var lista = new ListarSeguradoRepositorio().Listar();
            gvSegurado.DataSource = lista.ToList();
            gvSegurado.DataBind();
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguradoDetalhe.aspx");
        }
    }
}