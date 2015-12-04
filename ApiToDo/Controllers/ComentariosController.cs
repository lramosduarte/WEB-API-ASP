using ApiToDo.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiToDo.Controllers
{
    public class ComentariosController : ApiController
    {
        private todosEntities db = new todosEntities();
        private tarefasEntitiesNew teste = new tarefasEntitiesNew();
        
        [Route("api/todos/comentarios")]
        [Route("api/comentarios")]
        public Dictionary<string, IEnumerable<comentarios1>> Get()
        {
            var lista = teste.comentarios1.AsEnumerable();
            var dict = new Dictionary<string, IEnumerable<comentarios1>>();
            dict.Add("comentario", lista);
            
            return dict;
        }

        [Route("api/todos/{id}/comentarios")]
        [Route("api/comentarios/{id}")]
        public Dictionary<string, List<comentarios1>> Get(int id)//List<comentarios1> Get(int id)
        {

            List<comentarios1> items;

            using (var comment = new tarefasEntitiesNew())
            {
                items =     (from comentarios1 in comment.comentarios1
                            where comentarios1.tarefas_id == id
                            select comentarios1).ToList();
            }

            var dict = new Dictionary<string, List<comentarios1>>();
            dict.Add("comentario", items);

            return dict;

        }
    }
}
