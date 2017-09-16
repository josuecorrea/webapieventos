using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiEventosCore.Models;

namespace ApiEventosCore.Controllers
{
    [Route("api/[controller]")]
    public class EventoController : Controller
    {        
        // GET: api/values
        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return new List<Evento>();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Evento Get(int id)
        {
            return new Evento();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Evento evento)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
