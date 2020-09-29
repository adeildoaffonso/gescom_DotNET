using GESCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GERCOM.repositorio
{
    public class ListarCotacaoRepositorio
    {
        public IEnumerable<cotacao_tb> Listar()
        {
            System.Net.Http.HttpResponseMessage response = new API_GESCOM().Listar("api/ramo/ListarRamo");

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                var cotacoes = response.Content.ReadAsAsync<IEnumerable<cotacao_tb>>().Result;

                return cotacoes;

            }
            else
            {
                //Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
                return null;
            }
        }
    }
}