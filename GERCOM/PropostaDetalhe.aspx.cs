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
    public partial class PropostaDetalhe : System.Web.UI.Page
    {
        EntityState estado;
        proposta_tb proposta;
        int cotacao_id;

        #region eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) CarregarTela();
        }

        protected void btnVoltar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PropostaLista.aspx");
        }

        protected void btnNovo_Click(object sender, EventArgs e)
        {
            estado = EntityState.Added;
            ViewState["vsEstado"] = estado;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            if ((EntityState)ViewState["vsEstado"] == EntityState.Added) inserir();
            else alterar();

            Response.Redirect("PropostaLista.aspx");

        }

        protected void btnComissao_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("ComissaoDetalhe.aspx?proposta_id={0}", proposta.proposta_id));
        }

        #endregion

        #region metodos

        private void CarregarTela()
        {
            if (!string.IsNullOrEmpty(Request["cotacao_id"])) cotacao_id = Convert.ToInt16(Request["cotacao_id"]);

            ViewState["vsCotacaoID"] = cotacao_id;


            if (!string.IsNullOrEmpty(Request["id"]))
            {
                proposta = new PropostaRepositorio().RecuperarPelaChave(Convert.ToInt32(Request["id"]));
                chkAgenciamento.Checked = Convert.ToBoolean(proposta.agenciamento);
                txtCodigo.Text = proposta.codigo.ToString();
                txtDataEmissao.Text = proposta.data_emissao.ToString();
                txtDataProposta.Text = proposta.data_proposta.ToString();
                txtParcelamento.Text = proposta.parcelamento.ToString();
                txtPremio.Text = proposta.premio_liquido.ToString();


                if (!string.IsNullOrEmpty(proposta.cotacao_id.ToString())) cotacao_id = proposta.cotacao_id;

                txtDataEmissao.Text = System.DateTime.Now.ToString();
                txtDataProposta.Text = System.DateTime.Now.ToString();

                if (!string.IsNullOrEmpty(Request["premio"])) txtPremio.Text = Request["premio"].ToString();

                txtPremio.Enabled = false;

                estado = EntityState.Modified;
            }
            else estado = EntityState.Added;

            ViewState["vsEstado"] = estado;
        }

        private void inserir()
        {
            proposta = new proposta_tb();

            carregarEntidade();

            using (var ctx = new CTX_GERCOM())
            {
                try
                {
                    ctx.proposta_tb.Add(proposta);
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
                proposta = new PropostaRepositorio().RecuperarPelaChave(ctx, Convert.ToInt32(Request["id"]));

                carregarEntidade();

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
            int diasDataVencimento = 0;
            decimal valorPremio;

            proposta.cotacao_id = (int)ViewState["vsCotacaoID"];
            proposta.agenciamento = Convert.ToInt16(chkAgenciamento.Checked);
            proposta.codigo = txtCodigo.Text;
            proposta.data_emissao = Convert.ToDateTime(txtDataEmissao.Text);
            proposta.data_proposta = Convert.ToDateTime(txtDataProposta.Text);
            proposta.parcelamento = Convert.ToInt16(txtParcelamento.Text);
            proposta.premio_liquido = Convert.ToDecimal(txtPremio.Text);
            proposta.agenciamento = Convert.ToInt16(chkAgenciamento.Checked);

            valorPremio = Math.Round(proposta.premio_liquido / Convert.ToDecimal(txtParcelamento.Text),2);

            for (var iPropostaParcela = 0; iPropostaParcela < proposta.parcelamento; iPropostaParcela++)
            {
                diasDataVencimento += 30;

                carregarPropostaParcela(iPropostaParcela + 1, valorPremio, diasDataVencimento);
            }

        }

        private void carregarPropostaParcela(int numeroParcela, decimal valorPremio, int diasDataVencimento)
        {
            Models.entidade.recibo_comissao_tb recibo_comissao = new Models.entidade.recibo_comissao_tb();
            using (proposta_parcela_tb proposta_parcela = new proposta_parcela_tb())
            {
                proposta_parcela.numero_parcela = numeroParcela;
                proposta_parcela.premio_liquido = valorPremio;
                proposta_parcela.data_vencimento = Convert.ToDateTime(proposta.data_emissao).AddDays(diasDataVencimento);

                if (!Convert.ToBoolean(proposta.agenciamento))
                {
                    //carregarReciboComissao(ref recibo_comissao
                    //                       , proposta_parcela.premio_liquido
                    //                       , proposta.percentual_comissao
                    //                       , diasDataVencimento
                    //                       , 6
                    //                       , 'C');

                    //proposta_parcela.recibo_comissao_tb.Add(recibo_comissao);
                }

                proposta.proposta_parcela_tb.Add(proposta_parcela);
                

            }
        }

        private void carregarReciboComissao(ref Models.entidade.recibo_comissao_tb recibo_comissao
                                            , decimal valorBruto
                                            , decimal percentualComissao
                                            ,  int diasDataVencimento
                                            , decimal percentualImposto
                                            , char tipoComissao)
        {
            recibo_comissao.valor_bruto = valorBruto;
            recibo_comissao.percentual_comissao = percentualComissao;
            //recibo_comissao.data_pagamento = Convert.ToDateTime(proposta.data_emissao).AddDays(diasDataVencimento);
            //recibo_comissao.imposto = percentualImposto;
            //recibo_comissao.valor_liquido = Math.Round(valorBruto - (valorBruto * (recibo_comissao.imposto / 100)),2);

            recibo_comissao.valor_liquido = Math.Round(recibo_comissao.valor_liquido * (recibo_comissao.percentual_comissao / 100),2);

            //recibo_comissao.tipo_comissao = tipoComissao;
        }



            #endregion


        }
}