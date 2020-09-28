using GESCOM.Models.entidade;
using GESCOM.interfaces;
using GESCOM.Models.entidade;
using GESCOM.repositorio;
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
    public partial class AgenciadorDetalhe : System.Web.UI.Page, IDetalhe
    {
        EntityState estado;
        agenciador_tb agenciador;

        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) CarregarTela();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AgenciadorLista.aspx");
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if ((EntityState)ViewState["vsEstado"] == EntityState.Added) Inserir();
            else Alterar();

            Response.Redirect("AgenciadorLista.aspx");

        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            estado = EntityState.Added;
        }

        #endregion

        #region metodos
        public void CarregarTela()
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                RecuperarDados();

                txtNome.Text = agenciador.pessoa_tb.nome;
                txtCPF_CNPJ.Text = agenciador.pessoa_tb.cpf_cnpj;
                txtEmail.Text = agenciador.pessoa_tb.email;

                estado = EntityState.Modified;
            }
            else estado = EntityState.Added;

            ViewState["vsEstado"] = estado;
        }

        public void Inserir()
        {
            agenciador = new agenciador_tb();

            CarregarEntidade();

            new AgenciadorRepositorio().Inserir(agenciador);

        }

        public void Alterar()
        {
           using (var ctx = new CTX_GERCOM())
            {
                RecuperarDados();

                CarregarEntidade();

                new AgenciadorRepositorio().Alterar(agenciador);
            }
        }

        public void CarregarEntidade()
        {
            pessoa_tb pessoa = new pessoa_tb();

            pessoa.nome = txtNome.Text;
            pessoa.cpf_cnpj = txtCPF_CNPJ.Text;
            pessoa.email = txtEmail.Text;

            pessoa.pessoa_id = agenciador.pessoa_tb.pessoa_id;

            agenciador.pessoa_tb = pessoa;
        }

        public void RecuperarDados()
        {
            agenciador = new AgenciadorRepositorio().RecuperarPelaChave(Convert.ToInt32(Request["id"]));
        }
        #endregion
    }
}