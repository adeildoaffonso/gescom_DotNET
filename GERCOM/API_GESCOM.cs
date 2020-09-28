using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GESCOM
{
    public class API_GESCOM
    {
        public void Inserir<T>(string nomeAPI, T classe)
        {
            //T tabela;

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(URL);

                var postTask = cliente.PostAsJsonAsync<T>(nomeAPI, classe);
                postTask.Wait();

            }
        }

        public void Alterar<T>(string nomeAPI, T classe)
        {
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(URL);
                var putTask = cliente.PutAsJsonAsync<T>(nomeAPI, classe);
                putTask.Wait();

            }
        }

        public System.Net.Http.HttpResponseMessage Listar(string nomeAPI)
        {
            HttpClient client;

            var s = ConfigurationManager.AppSettings["urlAPI"].ToString();

            client = new HttpClient();
            //client.BaseAddress = new Uri("http://localhost:40303");
            //client.BaseAddress = new Uri(ConfigurationManager.AppSettings["urlAPI"].ToString());
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return client.GetAsync(nomeAPI).Result;
        }
        public System.Net.Http.HttpResponseMessage RecuperarPelaChave(string nomeAPI)
        {
            HttpClient client;

            client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            return client.GetAsync(nomeAPI).Result;
        }

        public static string URL
        {
            get { return ConfigurationManager.AppSettings["urlAPI"].ToString(); }
        }
    }
}