using GESCOM;
using GESCOM.Models.entidade;
using GESCOM.repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GESCOM
{

    public partial class SeguradoDetalhe : System.Web.UI.Page
    {
        
        EntityState estado;
        segurado_tb segurado;

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

            Response.Redirect("SeguradoLista.aspx");

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguradoLista.aspx");
        }
        #endregion

        #region Métodos
        private void CarregarTela()
        {
            if (!string.IsNullOrEmpty(Request["id"]))
            {
                segurado = new Segurado().RecuperarPelaChave(Convert.ToInt32(Request["id"]));

                txtNome.Text = segurado.pessoa_tb.nome;
                txtCPF_CNPJ.Text = segurado.pessoa_tb.cpf_cnpj;
                txtEmail.Text = segurado.pessoa_tb.email;

                estado = EntityState.Modified;
            }
            else estado = EntityState.Added;

            ViewState["vsEstado"] = estado;

        }

        private void inserir()
        {
            segurado = new segurado_tb();

            pessoa_tb pessoa = new pessoa_tb();

            pessoa.nome = txtNome.Text;
            pessoa.cpf_cnpj = txtCPF_CNPJ.Text;
            pessoa.email = txtEmail.Text;

            segurado.pessoa_tb = pessoa;

            using (var ctx = new CTX_GERCOM())
            {
                try
                {
                    ctx.segurado_tb.Add(segurado);
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        private void alterar()
        {
            using (var ctx = new CTX_GERCOM())
            {
                segurado = new Segurado().RecuperarPelaChave(ctx, Convert.ToInt32(Request["id"]));

                pessoa_tb pessoa = new pessoa_tb();

                pessoa.nome = txtNome.Text;
                pessoa.cpf_cnpj = txtCPF_CNPJ.Text;
                pessoa.email = txtEmail.Text;


                try
                {
                    segurado.pessoa_tb = pessoa;
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public void RecuperarDados()
        {
            segurado = new SeguradoRepositorio().RecuperarPelaChave(Convert.ToInt32(Request["id"]));
        }


        #endregion
    }
}