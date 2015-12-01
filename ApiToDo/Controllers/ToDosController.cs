using ApiToDo.Models;
using Newtonsoft.Json;
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
        todosEntities db = new todosEntities();

        public Dictionary<string,IEnumerable<tarefa>> Get()
        {
            
            var lista = db.tarefas.AsEnumerable();
            var dict = new Dictionary<string, IEnumerable<tarefa>>();
            dict.Add("todos", lista);
            string jsonFile = JsonConvert.SerializeObject(dict);
            Dictionary<string, IEnumerable<tarefa>> dict2 = JsonConvert.DeserializeObject<Dictionary<string, IEnumerable<tarefa>>>(jsonFile);

            return dict;
        }
        
        public tarefa Get(int id)
        {
            var lista = db.tarefas.Find(id);

            return lista;
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody]tarefa value)
        {
            if (ModelState.IsValid)
            {
                value.concluido = Convert.ToString("0");
                db.tarefas.Add(value);
                db.SaveChanges();
            }

            return new HttpResponseMessage(HttpStatusCode.Created);

        }

        public void Put(int id, [FromBody]tarefa value)
        {
            value.id = id;
                
                if (value.concluido == "False")
                    value.concluido = "0";
                else
                    value.concluido = "1";
                db.Entry(value).State = EntityState.Modified;
                db.SaveChanges();
            
        }

        [HttpDelete]
        public void Delete(int id)
        {
             tarefa item = db.tarefas.Find(id);
            if (item != null)
            {
                db.tarefas.Remove(item);
                db.SaveChanges();
            }
        }
    }
}
