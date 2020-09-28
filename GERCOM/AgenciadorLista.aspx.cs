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
    public partial class AgenciadorLista : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            carregarGrid();
        }

        public void gvAgenciador_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                agenciador_tb obj = ((agenciador_tb)e.Row.DataItem);

                ((HyperLink)e.Row.FindControl("lnkEditar")).NavigateUrl = string.Concat("AgenciadorDetalhe?id=", obj.agenciador_id);
                ((HyperLink)e.Row.FindControl("lnkEditar")).Text = obj.agenciador_id.ToString();
            }
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgenciadorDetalhe.aspx");
        }

        #endregion

        #region metodos
        public void carregarGrid()
        {
            var agenciadores = new ListarAgenciadorRepositorio().Listar();

            if (agenciadores.Count() > 0)
            {
                gvAgenciador.DataSource = agenciadores.ToList();
                gvAgenciador.DataBind();
            }

        }

        #endregion
    }
}