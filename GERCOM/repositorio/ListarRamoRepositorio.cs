using GESCOM.Models.entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GESCOM.repositorio
{
    public class ListarRamoRepositorio
    {
        public IEnumerable<ramo_tb> Listar()
        {
            System.Net.Http.HttpResponseMessage response = new API_GESCOM().Listar("api/ramo/ListarRamo");

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                var ramos = response.Content.ReadAsAsync<IEnumerable<ramo_tb>>().Result;

                return ramos;

            }
            else
            {
                //Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
                return null;
            }
        }
    }
}