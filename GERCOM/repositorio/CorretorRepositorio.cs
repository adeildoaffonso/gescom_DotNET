using GESCOM.Models.entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GESCOM
{
    public class CorretorRepositorio
    {

        #region Constantes
        #endregion

        public corretor_tb RecuperarPelaChave(int chave)
        {
            System.Net.Http.HttpResponseMessage response = new API_GESCOM().RecuperarPelaChave(string.Format("api/corretor/RecuperarPelaChave/{0}", chave));

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                var corretor = response.Content.ReadAsAsync<corretor_tb>().Result;

                return corretor;

            }
            else
            {
                //Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
                return null;
            }

        }

        public corretor_tb RecuperarPeloCodigoSUSEP(string susep)
        {
            System.Net.Http.HttpResponseMessage response = new API_GESCOM().RecuperarPelaChave(string.Format("api/corretor/RecuperarPeloSUSEP/{0}", susep));

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                var corretor = response.Content.ReadAsAsync<corretor_tb>().Result;

                return corretor;

            }
            else
            {
                //Response.Write(response.StatusCode.ToString() + " - " + response.ReasonPhrase);
                return null;
            }

        }

        public void Inserir(corretor_tb corretor)
        {
            new API_GESCOM().Inserir<corretor_tb>("/api/Corretor/Incluir/", corretor);
        }

        public void Alterar(corretor_tb corretor)
        {
            new API_GESCOM().Alterar<corretor_tb>(string.Concat("/api/Corretor/Atualizar/", corretor.corretor_id), corretor);
        }

    }
}