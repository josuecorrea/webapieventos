using ApiEventosCore.Data;
using ApiEventosCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEventosCore.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<Usuario> ObterTodos()
        {
            using (var ctx = new EventosDataContext())
            {
                return ctx.Usuario.ToList();
            }
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<Usuario> BuscarPorId(int id)
        {
            using (var ctx = new EventosDataContext())
            {
                return await ctx.Usuario.FindAsync(id);
            }
        }

        // POST api/values
        [HttpPost]
        public async void Novo([FromBody]Usuario evento)
        {
            using (var ctx = new EventosDataContext())
            {
                await ctx.Usuario.AddAsync(evento);
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
                ctx.Usuario.Remove(await ctx.Usuario.FindAsync(id));
                await ctx.SaveChangesAsync();
            }
        }
    }
}