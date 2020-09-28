using GESCOM.Models.entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GESCOM.repositorio
{
    public class ListarAgenciadorRepositorio
    {
        public IEnumerable<agenciador_tb> Listar()
        {
            System.Net.Http.HttpResponseMessage response = new API_GESCOM().Listar("api/agenciador/ListarAgenciador");

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                var corretores = response.Content.ReadAsAsync<IEnumerable<agenciador_tb>>().Result;

                return corretores;

            }
            else
            {
                //Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
                return null;
            }
        }
    }
}