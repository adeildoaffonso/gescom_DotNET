using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GESCOM.Models.entidade;
using System.Net.Http;

namespace GESCOM.repositorio
{
    public class AgenciadorRepositorio
    {
        public agenciador_tb RecuperarPelaChave(int chave)
        {
            System.Net.Http.HttpResponseMessage response = new API_GESCOM().RecuperarPelaChave(string.Format("api/agenciador/RecuperarPelaChave/{0}", chave));

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                var agenciador = response.Content.ReadAsAsync<agenciador_tb>().Result;

                return agenciador;

            }
            else
            {
                //Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
                return null;
            }

        }

        public void Inserir(agenciador_tb agenciador)
        {
            new API_GESCOM().Inserir<agenciador_tb>("/api/agenciador", agenciador);
        }

        public void Alterar(agenciador_tb agenciador)
        {
            new API_GESCOM().Alterar<agenciador_tb>(string.Concat("/api/agenciador/Atualizar/", agenciador.agenciador_id), agenciador);
        }

    }
}