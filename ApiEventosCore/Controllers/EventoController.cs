using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiEventosCore.Models;
using Microsoft.Extensions.Configuration;
using ApiEventosCore.Data;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace ApiEventosCore.Controllers
{
    [Route("api/[controller]")]
    public class EventoController : Controller
    {
        ILoggerFactory _loggerFactory;
        public EventoController(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Evento> ObterTodos()
        {
            using (var ctx = new EventosDataContext())
            {
                //var logger = _loggerFactory.CreateLogger("Debug");
                //logger.LogInformation("Solicitou lista de eventos");
                return ctx.Evento.ToList();
            }
        }

        [HttpGet("{id}")]
        public async Task<Evento> BuscarPorId(int id)
        {
            using (var ctx = new EventosDataContext())
            {
                //_logger.LogInformation("Solicitou um Evento");
                return await ctx.Evento.FindAsync(id);
            }
        }

        [HttpPost]
        public async void Novo([FromBody]Evento evento)
        {
            using (var ctx = new EventosDataContext())
            {
               // _logger.LogInformation("Adicionou um novo Evento");
                await ctx.Evento.AddAsync(evento);
                await ctx.SaveChangesAsync();
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            using (var ctx = new EventosDataContext())
            {
               // _logger.LogInformation("Excluiu um Evento");
                ctx.Evento.Remove(await ctx.Evento.FindAsync(id));
                await ctx.SaveChangesAsync();
            }
        }
    }
}
