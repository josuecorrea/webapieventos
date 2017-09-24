using ApiEventosCore.Data;
using ApiEventosCore.Models;
using ApiEventosCore.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEventosCore.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("Policy")]
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
        public async Task<IActionResult> Novo([FromBody]Usuario usuario)
        {
            if (!VerificaSeUsuarioJaExiste(usuario.UserName))
            {
                using (var ctx = new EventosDataContext())
                {
                    usuario.Senha = EncryptPassword.Encode(usuario.Senha);
                    await ctx.Usuario.AddAsync(usuario);
                    await ctx.SaveChangesAsync();
                }

                return Ok(usuario);
            }
            else
            {
                return BadRequest("Já existe Usuário com este nome!");
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
        public async Task<IActionResult> CrieUsuarioPadrao()
        {

            if (!VerificaSeUsuarioJaExiste("admin"))
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

                return new JsonResult($"Usuario: {usuario.UserName} Senha: {senha}.");
            }
            else
            {
                return BadRequest("Já existe Usuário com este nome!");
            }

        }

        private bool VerificaSeUsuarioJaExiste(string userName)
        {
            using (var ctx = new EventosDataContext())
            {
                var usuario = (from u in ctx.Usuario
                             where u.UserName == userName
                             select u).FirstOrDefault();

                if (usuario == null)
                    return false;

            }

            return true;
        }
    }
}
