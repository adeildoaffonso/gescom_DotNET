using GESCOM.interfaces;
using GESCOM.Models.entidade;
using GESCOM.repositorio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GESCOM
{
    public partial class RamoDetalhe : System.Web.UI.Page, IDetalhe
    {
        EntityState estado;
        ramo_tb ramo;

        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) CarregarTela(); 
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("RamoLista.aspx");
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            estado = EntityState.Added;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if ((EntityState)ViewState["vsEstado"] == EntityState.Added) Inserir();
            else Alterar();

            Response.Redirect("RamoLista.aspx");

        }
        #endregion

        #region Métodos
        public void CarregarTela()
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                RecuperarDados();

                txtCodigo.Text = ramo.codigo;

                txtDescricao.Text = ramo.descricao;

                estado = EntityState.Modified;
            }
            else estado = EntityState.Added;

            ViewState["vsEstado"] = estado;
        }

        public void Inserir()
        {
            ramo = new ramo_tb();

            CarregarEntidade();

            new RamoRepositorio().Inserir(ramo);
        }

        public void Alterar()
        {
            RecuperarDados();

            CarregarEntidade();

            new RamoRepositorio().Alterar(ramo);
        }

        public void RecuperarDados()
        {
            ramo = new RamoRepositorio().RecuperarPelaChave(Convert.ToInt32(Request["id"]));
        }

        public void CarregarEntidade()
        {
            ramo.codigo = txtCodigo.Text;
            ramo.descricao = txtDescricao.Text;
        }
        #endregion
    }
}