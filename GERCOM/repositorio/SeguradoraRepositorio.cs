using GESCOM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GESCOM.repositorio
{
    public class SeguradoraRepositorio
    {
        public seguradora_tb RecuperarPelaChave(int chave)
        {
            System.Net.Http.HttpResponseMessage response = new API_GESCOM().RecuperarPelaChave(string.Format("api/seguradora/RecuperarPelaChave/{0}", chave));

            if (response.IsSuccessStatusCode)
            {
                var seguradora = response.Content.ReadAsAsync<seguradora_tb>().Result;

                return seguradora;
            }
            else return null;
        }

        public void Inserir(seguradora_tb seguradora)
        {
            //new API_GESCOM().Inserir<ramo_tb>(string.Concat(API_GESCOM.URL, "/api/ramo/Incluir"), "ramo", ramo);
            new API_GESCOM().Inserir<seguradora_tb>("/api/seguradora/Incluir", seguradora);
        }

        public void Alterar(seguradora_tb seguradora)
        {
            using (var ctx = new CTX_GERCOM())
            {
                new API_GESCOM().Alterar<seguradora_tb>(string.Concat(API_GESCOM.URL, "/api/seguradora/{0}", seguradora.seguradora_id), seguradora);
            }
        }

    }
}