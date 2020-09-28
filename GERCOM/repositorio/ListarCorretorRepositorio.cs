using GESCOM.Models.entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace GESCOM.repositorio
{
    public class ListarCorretorRepositorio
    {
        public IEnumerable<corretor_tb> Listar()
        {
            System.Net.Http.HttpResponseMessage response = new API_GESCOM().Listar("api/corretor/ListarTodos");

            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                var corretores = response.Content.ReadAsAsync<IEnumerable<corretor_tb>>().Result;

                return corretores;

            }
            else return null;
        }
    }
}