using ApiToDo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiToDo.Controllers
{
    public class ComentariosController : ApiController
    {
        private todosEntities db = new todosEntities();
        public Dictionary<string, IEnumerable<comentario>> Get()
        {
            var lista = db.comentarios.AsEnumerable();
            var dict = new Dictionary<string, IEnumerable<comentario>>();
            dict.Add("comentario", lista);
            
            return dict;
        }
    }
}
