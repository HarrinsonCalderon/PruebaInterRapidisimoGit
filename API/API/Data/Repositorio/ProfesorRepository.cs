using API.Data.ContextoDb;
using API.Domain.Interfaces;
using API.Domain.Modelos;
using Dapper;
using System.Data.SqlClient;

namespace API.Data.Repositorio
{
    public class ProfesorRepository : IProfesorRepository
    {
        private string cadena;
        ContextoDB db;
            public ProfesorRepository(/*ContextoDB conex*/)
            {
            db = new ContextoDB();
              cadena = db.cadenaSql;                     
            }

        public  IEnumerable<Profesor> GetProfesor()
        {
            
                using (var connection = new SqlConnection(cadena))
                {
                    return  connection.Query<Profesor>("PR_ObtenerProfesor", commandType: System.Data.CommandType.StoredProcedure);
                } 
        }

         
    }
}
