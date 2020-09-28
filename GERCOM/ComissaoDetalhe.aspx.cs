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
    public partial class ComissaoDetalhe : System.Web.UI.Page
    {
        EntityState estado;
        recibo_comissao_tb comissao;
        int proposta_id;

        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) CarregarTela();




            if (!string.IsNullOrEmpty(Request["id"]))
            {
                comissao = new ComissaoRepositorio().RecuperarPelaChave(Convert.ToInt32(Request["id"]));

                //chkAgenciamento.Checked = Convert.ToBoolean(proposta.agenciamento);
                //txtCodigo.Text = proposta.codigo.ToString();
                //txtDataEmissao.Text = proposta.data_emissao.ToString();
                //txtDataProposta.Text = proposta.data_proposta.ToString();
                //txtParcelamento.Text = proposta.parcelamento.ToString();
                //txtPremio.Text = proposta.premio_liquido.ToString();
                //txtPercentual.Text = proposta.percentual_comissao.ToString();
                //chkAgenciamento.Checked = Convert.ToBoolean(proposta.agenciamento);

                estado = EntityState.Modified;
            }
            else estado = EntityState.Added;



            if (!string.IsNullOrEmpty(Request["proposta_id"]))
            {
                proposta_id = Convert.ToInt16(Request["proposta_id"]);
                proposta_tb proposta = new PropostaRepositorio().RecuperarPelaChave(proposta_id);
                //txtValorBruto.Text = proposta.premio_liquido.ToString();
            }

            //else if (!string.IsNullOrEmpty(comissao.recibo_comissao_id.ToString())) cotacao_id = proposta.cotacao_id;

            //txtDataEmissao.Text = System.DateTime.Now.ToString();
            //txtDataProposta.Text = System.DateTime.Now.ToString();
            ////txtPremio.Text = string.IsNullOrEmpty(Request["premio"]) ? "" : Request["premio"].ToString();
            txtValorBruto.Enabled = false;
            txtValorLiquido.Enabled = false;

        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PropostaLista.aspx");
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            estado = EntityState.Added;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if (estado == EntityState.Added) inserir();
            else alterar();

            Response.Redirect("PropostaLista.aspx");

        }

        protected void btnComissao_Click(object sender, EventArgs e)
        {
            Response.Redirect("GerarComissaoDetalhe.aspx");
        }

        //protected void txt_Imposto_

        #endregion

        #region metodos

        private void CarregarTela()
        {





            var corretores = new ListarCorretorRepositorio().Listar();


            carregarCorretor((List<corretor_tb>)corretores);

            var agenciadores = new ListarAgenciadorRepositorio().Listar();

            carregarAgenciador((List<agenciador_tb>)agenciadores);

            if (!string.IsNullOrEmpty(Request["id"]))
            {
                comissao = new ComissaoRepositorio().RecuperarPelaChave(Convert.ToInt32(Request["id"]));

                //chkAgenciamento.Checked = Convert.ToBoolean(proposta.agenciamento);
                //txtCodigo.Text = proposta.codigo.ToString();
                //txtDataEmissao.Text = proposta.data_emissao.ToString();
                //txtDataProposta.Text = proposta.data_proposta.ToString();
                //txtParcelamento.Text = proposta.parcelamento.ToString();
                //txtPremio.Text = proposta.premio_liquido.ToString();
                //txtPercentual.Text = proposta.percentual_comissao.ToString();
                //chkAgenciamento.Checked = Convert.ToBoolean(proposta.agenciamento);
            }
        }

        private void inserir()
        {
            comissao = new recibo_comissao_tb();
            carregarEntidade();

            using (var ctx = new CTX_GERCOM())
            {
                try
                {
                    ctx.recibo_comissao_tb.Add(comissao);
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
                //proposta = new PropostaRepositorio().RecuperarPelaChave(ctx, Convert.ToInt32(Request["id"]));

                //carregarEntidade();

                try
                {
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        private void carregarEntidade()
        {
            
            decimal valorLiquido = 0;
            decimal valorParcelaComissao = 0;
            decimal valorParcelaAgenciamento = 0;

            if (proposta_id > 0)
            {
                proposta_tb proposta = new PropostaRepositorio().RecuperarPelaChave(proposta_id);

                comissao.proposta_id = proposta_id;
                comissao.percentual_imposto = Math.Round(Convert.ToDecimal(txtImposto.Text),2);
                comissao.percentual_comissao = Math.Round(Convert.ToDecimal(txtComissaoProposta.Text), 2);
                comissao.valor_bruto = proposta.premio_liquido;
                comissao.valor_liquido = calculaValorLiquido(comissao.valor_bruto, comissao.percentual_comissao, comissao.percentual_imposto);

                valorParcelaComissao = calculaValorLiquido(comissao.valor_liquido, Convert.ToDecimal(txtComissionamento.Text));

                foreach (var parcela in proposta.proposta_parcela_tb)
                {
                    var comissaoDetalhe = new recibo_comissao_detalhe_tb();
                    comissaoDetalhe.data_pagamento = parcela.data_vencimento;
                    comissaoDetalhe.percentual_comissao = Math.Round(Convert.ToDecimal(txtComissionamento.Text), 2);
                    comissaoDetalhe.valor_pagamento = valorParcelaComissao;
                    comissaoDetalhe.status_pagamento = 0;
                    comissaoDetalhe.corretor_id = Convert.ToInt16(ddlCorretor.SelectedValue);

                    comissao.recibo_comissao_detalhe_tb.Add(comissaoDetalhe);
                }

                if(Convert.ToBoolean(proposta.agenciamento))
                {
                    valorParcelaAgenciamento = calculaValorLiquido(comissao.valor_liquido, Convert.ToDecimal(txtAgenciamento.Text));

                    foreach (var parcela in proposta.proposta_parcela_tb)
                    {
                        var agenciamentoDetalhe = new recibo_agenciamento_detalhe_tb();
                        agenciamentoDetalhe.data_pagamento = parcela.data_vencimento;
                        agenciamentoDetalhe.percentual_comissao = Math.Round(Convert.ToDecimal(txtAgenciamento.Text), 2);
                        agenciamentoDetalhe.valor_pagamento = valorParcelaAgenciamento;
                        agenciamentoDetalhe.status_pagamento = 0;
                        agenciamentoDetalhe.agenciador_id = Convert.ToInt16(ddlAgenciador.SelectedValue);

                        comissao.recibo_agenciamento_detalhe_tb.Add(agenciamentoDetalhe);
                    }
                }
            }


            //comissao.valor_bruto = parcela.premio_liquido;
            //comissao.percentual_comissao = Math.Round(Convert.ToDecimal(txtPercentual.Text), 2);
            //comissao.valor_liquido = Math.Round(((comissao.valor_bruto * comissao.imposto) * comissao.percentual_comissao),2);
            //comissao.data_pagamento = parcela.data_vencimento;
        }

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

        protected void carregarAgenciador(List<agenciador_tb> lista)
        {

            ddlAgenciador.Items.Clear();


            ListItem item = null;

            item = new ListItem();

            item.Value = "";
            item.Text = "SELECIONE";

            ddlAgenciador.Items.Add(item);

            foreach (agenciador_tb c in lista)
            {
                item = new ListItem();

                item.Value = c.agenciador_id.ToString();
                item.Text = c.pessoa_tb.nome;

                ddlAgenciador.Items.Add(item);
            }

        }

        protected decimal calculaValorLiquido(decimal valorBruto,  decimal comissao, decimal imposto = 0)
        {
            decimal valor_aux;

            if (imposto > 0) valor_aux = Math.Round(valorBruto - (valorBruto * (imposto / 100)), 2);
            else valor_aux = valorBruto;

            return Math.Round(valor_aux * (comissao / 100), 2);
        }



        #endregion
    }
}