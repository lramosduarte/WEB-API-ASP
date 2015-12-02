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
        private tarefasEntitiesNew teste = new tarefasEntitiesNew();
        public Dictionary<string, IEnumerable<comentarios1>> Get()
        {
            var lista = teste.comentarios1.AsEnumerable();
            var dict = new Dictionary<string, IEnumerable<comentarios1>>();
            dict.Add("comentario", lista);
            
            return dict;
        }
    }
}
