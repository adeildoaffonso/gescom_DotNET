using GESCOM.Models.entidade;
using GESCOM.repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GESCOM
{
    public partial class RamoLista : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            carregarGrid();
        }

        public void gvRamo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ramo_tb obj = ((ramo_tb)e.Row.DataItem);

                ((HyperLink)e.Row.FindControl("lnkEditar")).NavigateUrl = string.Concat("RamoDetalhe?id=", obj.ramo_id);
                ((HyperLink)e.Row.FindControl("lnkEditar")).Text = obj.codigo;
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("RamoDetalhe.aspx");
        }

        #endregion

        #region metodos
        public void carregarGrid()
        {
            //se retornar com sucesso busca os dados
            var ramos = new ListarRamoRepositorio().Listar();

            if(ramos.Count() > 0)
            {
                gvRamo.DataSource = ramos.ToList();
                gvRamo.DataBind();
            }
        }

        #endregion

    }
}