using ApiEventosCore.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ApiEventosCore.Data
{
    public class EventoDapperDAO
    {
        private IConfiguration _configuracoes;
        public EventoDapperDAO(IConfiguration config)
        {
            _configuracoes = config;
        }

        public Evento ObterPorId(int id)
        {
            using (SqlConnection conexao = new SqlConnection(
                _configuracoes.GetConnectionString("BaseEventos")))
            {
                return conexao.QueryFirstOrDefault<Evento>(
                    "SELECT * FROM dbo.Evento " +
                    "WHERE EVEN_ID = @id ",
                    new { id = id });
            }
        }

        public List<Evento> ObterTodos()
        {
            using (SqlConnection conexao = new SqlConnection(
                _configuracoes.GetConnectionString("BaseEventos")))
            {

                var listaDeEventos = conexao.QueryFirstOrDefault<List<Evento>>(
                    "SELECT * FROM dbo.EVENTO ");

                return listaDeEventos.ToList();
            }
        }
    }
}
