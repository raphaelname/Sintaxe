using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Tabela1Controller : ApiController
    {
        static readonly ITabela1Repositorio repositorio = new Tabela1Repositorio();

        public IEnumerable<Tabela1> GetAllTabela1s()
        {
            return repositorio.GetAll();
        }

        public Tabela1 GetTabela1(int id)
        {
            Tabela1 item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Tabela1> GetTabela1sPorDescricao(string descricao)
        {
            return repositorio.GetAll().Where(
                p => string.Equals(p.descricao, descricao, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostTabela1(Tabela1 item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<Tabela1>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutTabela1(int id, Tabela1 item)
        {
            item.id = id;
            if (!repositorio.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteTabela1(int id)
        {
            Tabela1 item = repositorio.Get(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repositorio.Remove(id);
        }
    }
}