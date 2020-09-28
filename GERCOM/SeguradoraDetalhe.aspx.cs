using GESCOM.Models.entidade;
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
    public partial class SeguradoraDetalhe : System.Web.UI.Page
    {
        EntityState estado;
        seguradora_tb seguradora;

        #region Constantes
        string API = "/api/seguradora/Incluir";
        #endregion

        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) CarregarTela();


        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguradoraLista.aspx");
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            estado = EntityState.Added;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if ((EntityState)ViewState["vsEstado"] == EntityState.Added) inserir();
            else alterar();

            Response.Redirect("SeguradoraLista.aspx");

        }
        #endregion

        #region Métodos
        private void CarregarTela()
        {

            if (!string.IsNullOrEmpty(Request["id"]))
            {
                RecuperarDados();

                if (seguradora == null) return;

                txtCodigo.Text = seguradora.seguradora_id.ToString();
                txtDescricao.Text = seguradora.pessoa_tb.nome;
                txtCNPJ.Text = seguradora.pessoa_tb.cpf_cnpj;
                txtEmail.Text = seguradora.pessoa_tb.email;

                estado = EntityState.Modified;
            }
            else estado = EntityState.Added;

            ViewState["vsEstado"] = estado;
        }

        private void inserir()
        {
            seguradora = new seguradora_tb();

            carregarEntidade();

            new API_GESCOM().Inserir<seguradora_tb>(API, seguradora);
        }

        private void alterar()
        {
            using (var ctx = new CTX_GERCOM())
            {
                RecuperarDados();

                carregarEntidade();

                new API_GESCOM().Alterar<seguradora_tb>(string.Concat("api/seguradora/Atualizar/", seguradora.seguradora_id), seguradora);
            }
        }

        private void carregarEntidade()
        {
            pessoa_tb pessoa = new pessoa_tb();

            pessoa.nome = txtDescricao.Text;
            pessoa.cpf_cnpj = txtCNPJ.Text;
            pessoa.email = txtEmail.Text;
            pessoa.pessoa_id = seguradora.pessoa_id;

            seguradora.pessoa_tb = pessoa;
        }

        private void RecuperarDados()
        {
            System.Net.Http.HttpResponseMessage response = new API_GESCOM().RecuperarPelaChave(string.Format("api/seguradora/RecuperarPelaChave/{0}", Convert.ToInt32(Request["id"])));

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
                seguradora = response.Content.ReadAsAsync<seguradora_tb>().Result;
            else
                Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
        }
        #endregion
    }
}