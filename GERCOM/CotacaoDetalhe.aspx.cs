using GESCOM.Models.entidade;
using GESCOM.repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GESCOM
{
    public partial class CotacaoDetalhe : System.Web.UI.Page
    {

        EntityState estado;
        cotacao_tb cotacao;
        int cotacao_id;

        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) CarregarTela();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CotacaoLista.aspx");
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            estado = EntityState.Added;
            ViewState["vsEstado"] = estado;
        }

        protected void btnProposta_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("PropostaDetalhe.aspx?cotacao_id={0}&premio={1}", (int)ViewState["vsCotacao"], txtPremio.Text));
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if ((EntityState)ViewState["vsEstado"] == EntityState.Added) inserir();
            else alterar();

            ViewState["vsCotacao"] = cotacao.cotacao_id;

            Response.Redirect("CotacaoLista.aspx");

        }



        #endregion

        #region metodos
        protected void carregarCorretor(List<corretor_tb> lista)
        {
            ddlCorretor.Items.Clear();

            ListItem item = null;

            item = new ListItem();

            item.Value = "";
            item.Text = "SELECIONE";

            ddlCorretor.Items.Add(item);

            foreach (corretor_tb c in lista)
            {
                item = new ListItem();

                item.Value = c.corretor_id.ToString();
                item.Text = c.pessoa_tb.nome;

                ddlCorretor.Items.Add(item);
            }

        }

        protected void carregarSegurado(List<segurado_tb> lista)
        {
            ddlSegurado.Items.Clear();

            ListItem item = null;

            item = new ListItem();

            item.Value = "";
            item.Text = "SELECIONE";

            ddlSegurado.Items.Add(item);

            foreach (segurado_tb c in lista)
            {
                item = new ListItem();

                item.Value = c.segurado_id.ToString();
                item.Text = c.pessoa_tb.nome;

                ddlSegurado.Items.Add(item);
            }

            ddlSegurado.DataBind();
        }

        protected void carregarRamo(List<ramo_tb> lista)
        {

            ddlRamo.Items.Clear();


            ListItem item = null;

            item = new ListItem();

            item.Value = "";
            item.Text = "SELECIONE";

            ddlRamo.Items.Add(item);

            foreach (ramo_tb c in lista)
            {
                item = new ListItem();

                item.Value = c.ramo_id.ToString();
                item.Text = c.descricao;

                ddlRamo.Items.Add(item);
            }

        }

        protected void carregarSeguradora(IEnumerable<seguradora_tb> lista)
        {

            ddlSeguradora.Items.Clear();
            ListItem item = null;

            item = new ListItem();

            item.Value = "";
            item.Text = "SELECIONE";

            ddlSeguradora.Items.Add(item);

            foreach (seguradora_tb c in lista)
            {
                item = new ListItem();

                item.Value = c.seguradora_id.ToString();
                item.Text = c.pessoa_tb.nome;

                ddlSeguradora.Items.Add(item);
            }

        }

        protected void carregarDDL_Generica<T>(List<T> objeto, string valor, string texto)
        {
            Type tipo = typeof(T);
            PropertyInfo[] propriedades = tipo.GetProperties();

            ListItem item;
            bool bEncontrou;


            //sOLUÇÃO
            //prop.PropertyType.ToString().Contains("GESCOM");
            foreach (PropertyInfo prop in propriedades)
            {
                item = new ListItem();

                bEncontrou = false;
                if (prop.Name.Equals(valor))
                {
                    item.Value = prop.GetValue(objeto).ToString();
                    bEncontrou = true;

                }
                else if (prop.Name.Equals(texto))
                {
                    item.Text = prop.GetValue(objeto).ToString();
                    bEncontrou = true;
                }

                if (bEncontrou) ddlCorretor.Items.Add(item);
            }


            ddlCorretor.DataSource = null;

            item = new ListItem();

            item.Value = "1";
            item.Text = "ADEILDO AFFONSO";

            ddlCorretor.Items.Add(item);
        }

        protected void PosicionarDropDownList(ref DropDownList ddl, string valor)
        {
            ddl.SelectedIndex = ddl.Items.IndexOf(ddl.Items.FindByValue(valor));
        }

        private void CarregarTela()
        {

            var corretores = new ListarCorretorRepositorio().Listar();

            carregarCorretor((List<corretor_tb>) corretores);


            var ramos = new ListarRamoRepositorio().Listar();

            carregarRamo((List<ramo_tb>) ramos);

             var segurados = new ListarSeguradoRepositorio().Listar();
            carregarSegurado((List<segurado_tb>) segurados);

           var seguradoras = new ListaSeguradoraRepositorio().Listar();
            carregarSeguradora(seguradoras);

            if (!string.IsNullOrEmpty(Request["id"]))
            {
                cotacao = new CotacaoRepositorio().RecuperarPelaChave(Convert.ToInt32(Request["id"]));

                cotacao_id = cotacao.cotacao_id;

                ViewState["vsCotacao"] = cotacao_id;

                estado = EntityState.Modified;

                txtCodigo.Text = cotacao.codigo;
                txtPremio.Text = Convert.ToString(cotacao.premio);
                txtDataCotacao.Text = Convert.ToString(cotacao.data_cotacao);
                txtInicioVigencia.Text = Convert.ToString(cotacao.data_inicio_vigencia);
                txtFimVigencia.Text = Convert.ToString(cotacao.data_fim_vigencia);

                PosicionarDropDownList(ref ddlSegurado, cotacao.segurado_id.ToString());
                PosicionarDropDownList(ref ddlRamo, cotacao.ramo_id.ToString());
                PosicionarDropDownList(ref ddlCorretor, cotacao.corretor_id.ToString());
                PosicionarDropDownList(ref ddlSeguradora, cotacao.seguradora_id.ToString());

            }
            else estado = EntityState.Added;

            ViewState["vsEstado"] = estado;
        }

        private void inserir()
        {
            cotacao = new cotacao_tb();

            carregarEntidade();

            new CotacaoRepositorio().Inserir(cotacao);

            Response.Redirect("CotacaoLista.aspx");
        }

        private void alterar()
        {
            using (var ctx = new CTX_GERCOM())
            {
                cotacao = new CotacaoRepositorio().RecuperarPelaChave(Convert.ToInt32(Request["id"]));

                carregarEntidade();

                new CotacaoRepositorio().Alterar(cotacao);

                Response.Redirect("CotacaoLista.aspx");
            }
        }

        private void carregarEntidade()
        {
            cotacao.codigo = txtCodigo.Text;
            cotacao.premio = Convert.ToDecimal(txtPremio.Text);
            cotacao.data_cotacao = Convert.ToDateTime(txtDataCotacao.Text);
            cotacao.data_inicio_vigencia = Convert.ToDateTime(txtInicioVigencia.Text);
            cotacao.data_fim_vigencia = Convert.ToDateTime(txtFimVigencia.Text);

            cotacao.segurado_id = Convert.ToInt16(ddlSegurado.SelectedValue);
            cotacao.ramo_id = Convert.ToInt16(ddlRamo.SelectedValue);
            cotacao.corretor_id = Convert.ToInt16(ddlCorretor.SelectedValue);
            cotacao.seguradora_id = Convert.ToInt16(ddlSeguradora.SelectedValue);
        }



        #endregion

        
    }
}