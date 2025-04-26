using API.Data.ContextoDb;
using API.Domain.Interfaces;
using API.Domain.Modelos;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace API.Data.Repositorio
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private string cadena;
        ContextoDB db;
            public EstudianteRepository(/*ContextoDB conex*/)
            {
            db = new ContextoDB();
              cadena = db.cadenaSql;                     
            }

        public void DeleteEstudiant(string? id = null)
        {
            using (var connection = new SqlConnection(cadena))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                connection.Execute("PR_EliminarEstudiante", parameters,commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public  IEnumerable<Estudiante> GetEstudiante()
        {
            
                using (var connection = new SqlConnection(cadena))
                {
                    return  connection.Query<Estudiante>("PR_ObtenerEstudiante", commandType: System.Data.CommandType.StoredProcedure);
                } 
        }

        public IEnumerable<EstudianteClase> GetEstudianteClase(string? id = null)
        {
            using (var connection = new SqlConnection(cadena))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return connection.Query<EstudianteClase>("PR_ObtenerEstudianteClase", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public IEnumerable<EstudiantePrograma> GetEstudiantePrograma(string? id = null)
        {
            using (var connection = new SqlConnection(cadena))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                return connection.Query<EstudiantePrograma>("PR_ObtenerEstudiantePrograma",parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public void PostEstudiante(Estudiante e)
        {

            using (var connection = new SqlConnection(cadena))
            {
                var parameters = new DynamicParameters();
         
                parameters.Add("@nombre", e.Nombre);
                parameters.Add("@fkidprograma", e.Fkidprograma);


                connection.Execute("PR_InsertarEstudiante", parameters,
                           commandType: CommandType.StoredProcedure);
            }
        }

        public void PostEstudiante(EstudianteCreacion e)
        {
            

            using (var connection = new SqlConnection(cadena))
            {
                var parameters = new DynamicParameters();

                parameters.Add("@nombre", e.Nombre);
                parameters.Add("@fkidprograma", e.fkidprograma);


                connection.Execute("PR_InsertarEstudiante", parameters,
                           commandType: CommandType.StoredProcedure);
            }
            //Insertar materias estudiante
            e.materia = e.materia.Substring(1,e.materia.Length-2);

            string[]materias = e.materia.Split(",");
            
            foreach(var it in materias)
            {
                using (var connection = new SqlConnection(cadena))
                {
                    var parameters = new DynamicParameters();

                    parameters.Add("@fkidmateria", it);
                    connection.Execute("PR_InsertarEstudianteMateria", parameters,
                               commandType: CommandType.StoredProcedure);
                }
            }
        }
        //Terminar
        public void PostEstudianteActualizar(EstudianteActualizacion e)
        {
            using (var connection = new SqlConnection(cadena))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@id", e.Id);
                parameters.Add("@nombre", e.Nombre);
                parameters.Add("@fkidprograma", e.fkidprograma);
             

                connection.Execute("PR_ActualizarEstudiante", parameters,
                           commandType: CommandType.StoredProcedure);
            }
            //Insertar materias estudiante
            e.materia = e.materia.Substring(1, e.materia.Length - 2);
            //e.estudiantemateria = e.estudiantemateria.Substring(0, e.estudiantemateria.Length - 2);

            string[] materias = e.materia.Split(",");
            string[] estudiantematerias = e.estudiantemateria.Split(",");


            for (int i= 0;i < materias.Length;i++)
            {
                using (var connection = new SqlConnection(cadena))
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("@id", e.Id);
                    parameters.Add("@materia", materias[i]);
                    parameters.Add("@estudiantemateria", estudiantematerias[i]);
                    connection.Execute("PR_ActualizarEstudianteMateria", parameters,
                               commandType: CommandType.StoredProcedure);
                }
            }
        }
    }
}
