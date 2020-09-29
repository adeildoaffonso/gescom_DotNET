using GESCOM;
using GESCOM.Models.entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GESCOM.repositorio
{
    public class CotacaoRepositorio
    {
        public cotacao_tb RecuperarPelaChave(int chave)
        {
            System.Net.Http.HttpResponseMessage response = new API_GESCOM().RecuperarPelaChave(string.Format("api/cotacao/{0}", chave));

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                var cotacao = response.Content.ReadAsAsync<cotacao_tb>().Result;

                return cotacao;

            }
            else
            {
                //Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
                return null;
            }


        }

        public void Inserir(cotacao_tb cotacao)
        {
            new API_GESCOM().Inserir<cotacao_tb>("/api/cotacao/Incluir", cotacao);
        }

        public void Alterar(cotacao_tb cotacao)
        {
            using (var ctx = new CTX_GERCOM())
            {
                new API_GESCOM().Alterar<cotacao_tb>(string.Concat(API_GESCOM.URL, "/api/cotacao/Atualizar/", cotacao.cotacao_id), cotacao);
            }
        }
    }
}