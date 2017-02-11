using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class UsuarioController : ApiController
    {
        public IEnumerable<Models.Usuario> Get()
        {
            Models.BancoDataContext dc = new Models.BancoDataContext();
            var listaUsuarios = from f in dc.Usuarios select f;
            return listaUsuarios.ToList();
        }

        public void Post([FromBody]Models.Usuario usuario)
        {
            Models.BancoDataContext dc = new Models.BancoDataContext();
            dc.Usuarios.InsertOnSubmit(new Models.Usuario() { Id = usuario.Id, Nome = usuario.Nome, Senha = usuario.Senha });
            dc.SubmitChanges();
        }

        // DELETE api/values/5]
        public void Delete(int Id)
        {
            Models.BancoDataContext dc = new Models.BancoDataContext();
            var usuario = (from f in dc.Usuarios where f.Id == Id select f).Single();
            dc.Usuarios.DeleteOnSubmit(usuario);
            dc.SubmitChanges();
        }
    }
}
