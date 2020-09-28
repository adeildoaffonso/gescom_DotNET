using GESCOM.Models.entidade;
using GESCOM.repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GESCOM
{
    public partial class CorretorLista : System.Web.UI.Page
    {
        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            carregarGrid();
        }
        public void gvCorretor_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                corretor_tb obj = ((corretor_tb)e.Row.DataItem);

                ((HyperLink)e.Row.FindControl("lnkEditar")).NavigateUrl = string.Concat("CorretorDetalhe?susep=", obj.codigo_susep);
                ((HyperLink)e.Row.FindControl("lnkEditar")).Text = obj.codigo_susep.ToString();
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("CorretorDetalhe.aspx");
        }

        #endregion

        #region metodos
        public void carregarGrid()
        {
            var lista = new ListarCorretorRepositorio().Listar();
            gvCorretor.DataSource = lista.ToList();
            gvCorretor.DataBind();
        }
        #endregion

    }
}