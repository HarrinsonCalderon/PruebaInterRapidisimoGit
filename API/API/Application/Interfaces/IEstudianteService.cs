

using API.Domain.Modelos;

namespace API.Application.Interfaces
{
    public interface IEstudianteService
    {
        public IEnumerable<Estudiante> GetEstudiante();

        public IEnumerable<EstudianteClase> GetEstudianteClase(string? id = null);
        public void PostEstudiante(Estudiante e);

        public void PostEstudiante(EstudianteCreacion e);

        public void PostEstudianteActualizar(EstudianteActualizacion e);

        public IEnumerable<EstudiantePrograma> GetEstudiantePrograma(string? id = null);

        public void DeleteEstudiant(string? id = null);

    }
}
