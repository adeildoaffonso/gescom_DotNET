using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GESCOM
{
    public class ListaSeguradoraRepositorio
    {
        public List<seguradora_tb> listar1()
        {
            CTX_GERCOM ctx = new CTX_GERCOM();
            return ctx.seguradora_tb.ToList();
        }

        public IEnumerable<seguradora_tb> Listar()
        {
            System.Net.Http.HttpResponseMessage response = new API_GESCOM().Listar("api/seguradora/ListarSeguradora");

            if (response.IsSuccessStatusCode)
            {
                var seguradoras = response.Content.ReadAsAsync<IEnumerable<seguradora_tb>>().Result;
                return seguradoras;
            }
            else return null;
        }
    }
}