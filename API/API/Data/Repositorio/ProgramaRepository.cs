using API.Data.ContextoDb;
using API.Domain.Interfaces;
using API.Domain.Modelos;
using Dapper;
using System.Data.SqlClient;

namespace API.Data.Repositorio
{
    public class ProgramaRepository : IProgramaRepository
    {
            private string cadena;
            ContextoDB db;
            public ProgramaRepository(/*ContextoDB conex*/){
              db = new ContextoDB();
              cadena = db.cadenaSql;                     
            }

        public IEnumerable<Programa> GetPrograma()
        {
            using (var connection = new SqlConnection(cadena))
            {
                return connection.Query<Programa>("PR_ObtenerPrograma", commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
