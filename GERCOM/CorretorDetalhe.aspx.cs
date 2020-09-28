using GESCOM.Models.entidade;
using GESCOM.Models.entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GESCOM
{
    public partial class CorretorDetalhe : System.Web.UI.Page
    {
        EntityState estado;
        corretor_tb corretor;

        #region eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) CarregarTela();

        }
        protected void btnNovo_Click(object sender, EventArgs e)
        {
            estado = EntityState.Added;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if ((EntityState)ViewState["vsEstado"] == EntityState.Added) inserir();
            else alterar();

            Response.Redirect("CorretorLista.aspx");

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CorretorLista.aspx");
        }
        #endregion

        #region Métodos
        private void CarregarTela()
        {

           if (!string.IsNullOrEmpty(Request["susep"]))
            {
                RecuperarDados();

                txtNome.Text = corretor.pessoa_tb.nome;
                txtCPF_CNPJ.Text = corretor.pessoa_tb.cpf_cnpj;
                txtEmail.Text = corretor.pessoa_tb.email;
                txtCodigoSUSEP.Text = corretor.codigo_susep;

                estado = EntityState.Modified;
            }
            else estado = EntityState.Added;

            ViewState["vsEstado"] = estado;

        }

        private void inserir()
        {
            corretor = new corretor_tb();

            CarregarEntidade();

            new CorretorRepositorio().Inserir(corretor);
        }

        private void alterar()
        {
            using (var ctx = new CTX_GERCOM())
            {
                corretor = new CorretorRepositorio().RecuperarPeloCodigoSUSEP(Request["susep"].ToString());

                corretor.pessoa_tb.nome = txtNome.Text;
                corretor.pessoa_tb.cpf_cnpj = txtCPF_CNPJ.Text;
                corretor.pessoa_tb.email = txtEmail.Text;

                corretor.codigo_susep = txtCodigoSUSEP.Text;

                try
                {
                    new CorretorRepositorio().Alterar(corretor);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public void RecuperarDados()
        {
            corretor = new CorretorRepositorio().RecuperarPeloCodigoSUSEP(Request["susep"].ToString());
        }

        public void CarregarEntidade()
        {
            pessoa_tb pessoa = new pessoa_tb();

            pessoa.nome = txtNome.Text;
            pessoa.cpf_cnpj = txtCPF_CNPJ.Text;
            pessoa.email = txtEmail.Text;

            corretor.codigo_susep = txtCodigoSUSEP.Text;
            corretor.pessoa_tb = pessoa;
        }

        #endregion
    }
}