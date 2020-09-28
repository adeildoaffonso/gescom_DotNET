using GESCOM.Models.entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GESCOM.repositorio
{
    public class RamoRepositorio
    {
        public ramo_tb RecuperarPelaChave(int chave)
        {
            System.Net.Http.HttpResponseMessage response = new API_GESCOM().RecuperarPelaChave(string.Format("api/ramo/{0}", chave));

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                var ramo = response.Content.ReadAsAsync<ramo_tb>().Result;

                return ramo;

            }
            else
            {
                //Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
                return null;
            }


        }

        public void Inserir(ramo_tb ramo)
        {
            //new API_GESCOM().Inserir<ramo_tb>(string.Concat(API_GESCOM.URL, "/api/ramo/Incluir"), "ramo", ramo);
            new API_GESCOM().Inserir<ramo_tb>("/api/ramo/Incluir", ramo);
        }

        public void Alterar(ramo_tb ramo)
        {
            using (var ctx = new CTX_GERCOM())
            {
                new API_GESCOM().Alterar<ramo_tb>(string.Concat(API_GESCOM.URL, "/api/ramo/Atualizar/", ramo.ramo_id), ramo);
            }
        }
    }

}