using API.Application.Interfaces;
using API.Data.Repositorio;
using API.Domain.Interfaces;
using API.Domain.Modelos;

namespace API.Application.Services
{
    public class EstudianteService : IEstudianteService
    {
        private readonly EstudianteRepository _Repository;

        public EstudianteService()
        {
            _Repository = new EstudianteRepository();   
        }

        public void DeleteEstudiant(string? id = null)
        {
            _Repository.DeleteEstudiant(id);
        }

        public IEnumerable<Estudiante> GetEstudiante()
        {
            return _Repository.GetEstudiante();
        }

        public IEnumerable<EstudianteClase> GetEstudianteClase(string? id = null)
        {
            return _Repository.GetEstudianteClase(id);
        }

        public IEnumerable<EstudiantePrograma> GetEstudiantePrograma(string? id = null)
        {
            return _Repository.GetEstudiantePrograma(id); 
        }

        public void PostEstudiante(Estudiante e)
        {
              _Repository.PostEstudiante(e);
        }
        public void PostEstudiante(EstudianteCreacion e)
        {
            _Repository.PostEstudiante(e);
        }

        public void PostEstudianteActualizar(EstudianteActualizacion e)
        {
            _Repository.PostEstudianteActualizar(e);
        }
    }
}
