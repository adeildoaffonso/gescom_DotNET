using GESCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GESCOM.repositorio
{
    public class SeguradoRepositorio
    {
        public segurado_tb RecuperarPelaChave(int chave)
        {
            System.Net.Http.HttpResponseMessage response = new API_GESCOM().RecuperarPelaChave(string.Format("api/segurado/RecuperarPelaChave/{0}", chave));

            if (response.IsSuccessStatusCode)
            {
                var segurado = response.Content.ReadAsAsync<segurado_tb>().Result;

                return segurado;
            }
            else return null;
        }

        public void Inserir(segurado_tb segurado)
        {
            new API_GESCOM().Inserir<segurado_tb>("/api/seguradora/Incluir", segurado);
        }

        public void Alterar(segurado_tb segurado)
        {
            using (var ctx = new CTX_GERCOM())
            {
                new API_GESCOM().Alterar<segurado_tb>(string.Concat(API_GESCOM.URL, "/api/segurado/{0}", segurado.segurado_id), segurado);
            }
        }
    }
}