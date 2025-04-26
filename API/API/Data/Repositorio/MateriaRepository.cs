using API.Data.ContextoDb;
using API.Domain.Interfaces;
using API.Domain.Modelos;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace API.Data.Repositorio
{
    public class MateriaRepository : IMateriaRepository
    {
        private string cadena;
        ContextoDB db;
            public MateriaRepository(/*ContextoDB conex*/)
            {
            db = new ContextoDB();
              cadena = db.cadenaSql;                     
            }

     
        public  IEnumerable<Materia> ObtenerMateria()
        {
            
                using (var connection = new SqlConnection(cadena))
                {
                    return  connection.Query<Materia>("PR_ObtenerMateria", commandType: System.Data.CommandType.StoredProcedure);
                } 
        }

        


    }
}
