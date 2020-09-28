using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GESCOM
{
    public class ListarSeguradoRepositorio
    {
        public IEnumerable<segurado_tb> Listar()
        {
            System.Net.Http.HttpResponseMessage response = new API_GESCOM().Listar("api/segurado/ListarSegurado");

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                var segurados = response.Content.ReadAsAsync<IEnumerable<segurado_tb>>().Result;

                return segurados;

            }
            else
            {
                //Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
                return null;
            }
        }
    }
}