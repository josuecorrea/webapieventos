using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiEventosCore.Models;
using Microsoft.Extensions.Configuration;
using ApiEventosCore.Data;

namespace ApiEventosCore.Controllers
{
    [Route("api/[controller]")]
    public class EventoController : Controller
    {
        private IConfiguration _configuracoes;
        public EventoController(IConfiguration config)
        {
            _configuracoes = config;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Evento> ObterTodos()
        {
            using (var ctx = new EventosDataContext())
            {
                return ctx.Evento.ToList();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Evento> BuscarPorId(int id)
        {
            using (var ctx = new EventosDataContext())
            {
               return await ctx.Evento.FindAsync(id);
            }
        }

        // POST api/values
        [HttpPost]
        public async void Novo([FromBody]Evento evento)
        {
            using (var ctx = new EventosDataContext())
            {
                await ctx.Evento.AddAsync(evento);
                await ctx.SaveChangesAsync();
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            using (var ctx = new EventosDataContext())
            {
                ctx.Evento.Remove(await ctx.Evento.FindAsync(id));
                await ctx.SaveChangesAsync();
            }
        }
    }
}
