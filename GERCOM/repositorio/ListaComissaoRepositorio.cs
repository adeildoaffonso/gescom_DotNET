using GESCOM.Models.entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GESCOM
{
    public class ListaComissaoRepositorio
    {
        public List<Models.entidade.recibo_comissao_tb> listar()
        {
            CTX_GERCOM ctx = new CTX_GERCOM();
            return ctx.recibo_comissao_tb.ToList();
        }

        public IEnumerable<Models.entidade.recibo_comissao_tb> Listar()
        {
            System.Net.Http.HttpResponseMessage response = new API_GESCOM().Listar("api/comissao/ListarComissao");

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                var comissao = response.Content.ReadAsAsync<IEnumerable<Models.entidade.recibo_comissao_tb>>().Result;

                return comissao;
            }
            else
            {
                //Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
                return null;
            }
        }

    }
}