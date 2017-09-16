using ApiEventosCore.Data;
using ApiEventosCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        [Authorize]
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
        [Authorize]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async void Delete(int id)
        {
            using (var ctx = new EventosDataContext())
            {
               // _logger.LogInformation("Excluiu um Evento");
                ctx.Evento.Remove(await ctx.Evento.FindAsync(id));
                await ctx.SaveChangesAsync();
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IEnumerable<Evento> ObterEventosPorUsuario(int id)
        {
            using (var ctx = new EventosDataContext())
            {
                return ctx.Evento.Where(c => c.Id == id).ToList();
            }
        }
    }
}
