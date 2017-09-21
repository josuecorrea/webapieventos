using ApiEventosCore.Data;
using ApiEventosCore.Models;
using ApiEventosCore.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEventosCore.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        [HttpGet]
        [Authorize]
        [Route("obtertodos")]
        public IEnumerable<Usuario> ObterTodos()
        {
            using (var ctx = new EventosDataContext())
            {
                return ctx.Usuario.ToList();
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        [Route("buscaporid")]
        public async Task<Usuario> BuscarPorId(int id)
        {
            using (var ctx = new EventosDataContext())
            {
                return await ctx.Usuario.FindAsync(id);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("novo")]
        public async void Novo([FromBody]Usuario usuario)
        {
            using (var ctx = new EventosDataContext())
            {
                usuario.Senha = EncryptPassword.Encode(usuario.Senha);
                await ctx.Usuario.AddAsync(usuario);
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
        [Route("delete")]
        public async void Delete(int id)
        {
            using (var ctx = new EventosDataContext())
            {
                ctx.Usuario.Remove(await ctx.Usuario.FindAsync(id));
                await ctx.SaveChangesAsync();
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("crieusuariopadrao")]
        public async Task<JsonResult> CrieUsuarioPadrao()
        {
            Usuario usuario;
            var senha = "123456";
            using (var ctx = new EventosDataContext())
            {
                usuario = new Usuario
                {
                    DataCadastro = DateTime.Now.Date,
                    Email = "admin@mail.com",
                    Nome = "admin",
                    Senha = senha,
                    UserName = "admin"

                };

                usuario.Senha = EncryptPassword.Encode(usuario.Senha);
                await ctx.Usuario.AddAsync(usuario);
                await ctx.SaveChangesAsync();
            }

            return new JsonResult($"Usuario: {usuario.UserName} Senha: {senha}." );
        }
    }
}
