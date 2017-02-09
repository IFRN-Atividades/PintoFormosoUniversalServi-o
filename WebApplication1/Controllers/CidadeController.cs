using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class CidadeController : ApiController
    {

        public IEnumerable<Models.Cidade> Get()
        {
            Models.BancoDataContext dc = new Models.BancoDataContext();
            var r1 = from r in dc.Cidades orderby r.Nome select r;
            return r1.ToList();
        }

        public void Post([FromBody] Models.Cidade cidade)
        {
            Models.BancoDataContext dc = new Models.BancoDataContext();
            dc.Cidades.InsertOnSubmit(new Models.Cidade() { Nome = cidade.Nome, IdEstado = cidade.IdEstado });
            dc.SubmitChanges();
        }

        public void Put(int id, [FromBody] Models.Cidade cidade)
        {
            Models.BancoDataContext dc = new Models.BancoDataContext();
            Models.Cidade cid = (from f in dc.Cidades where f.Id == id select f).Single();
            cid.Nome = cidade.Nome;
            cid.IdEstado = cidade.IdEstado;
            dc.SubmitChanges();
        }

        public void Delete(int id)
        {
            Models.BancoDataContext dc = new Models.BancoDataContext();
            Models.Cidade r = (from f in dc.Cidades where f.Id == id select f).Single();
            dc.Cidades.DeleteOnSubmit(r);
            dc.SubmitChanges();
        }

    }
}
