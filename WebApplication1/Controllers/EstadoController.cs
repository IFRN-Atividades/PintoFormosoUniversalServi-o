using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class EstadoController : ApiController
    {
        public IEnumerable<Models.Estado> Get()
        {
            Models.BancoDataContext dc = new Models.BancoDataContext();
            var r1 = from r in dc.Estados orderby r.Sigla select r;
            return r1.ToList();
        }
    }
}
