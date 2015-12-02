using ApiToDo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiToDo.Controllers
{
    public class ToDosController : ApiController
    {
        private todosEntities db = new todosEntities();
        private tarefasEntitiesNew teste = new tarefasEntitiesNew();
        public Dictionary<string, IEnumerable<tarefas1>> Get()
        {
            var lista = teste.tarefas1.AsEnumerable();
            var dict = new Dictionary<string, IEnumerable<tarefas1>>();
            dict.Add("todos", lista);
            
            return dict;
        }

        public tarefa Get(int id)
        {
            var lista = db.tarefas.Find(id);

            return lista;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]tarefas1 value)
        {
            if (ModelState.IsValid)
            {
                value.concluido = Convert.ToString("0");
                teste.tarefas1.Add(value);
                teste.SaveChanges();
            }

            return new HttpResponseMessage(HttpStatusCode.Created);

        }

        public void Put(int id, [FromBody]tarefas1 value)
        {
            value.id = id;
                
                if (value.concluido == "False")
                    value.concluido = "0";
                else
                    value.concluido = "1";
                teste.Entry(value).State = EntityState.Modified;
                teste.SaveChanges();
            
        }

        [HttpDelete]
        public void Delete(int id)
        {
            tarefas1 item = teste.tarefas1.Find(id);
            if (item != null)
            {
                teste.tarefas1.Remove(item);
                teste.SaveChanges();
            }
        }
    }
}
