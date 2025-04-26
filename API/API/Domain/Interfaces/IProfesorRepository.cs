using API.Domain.Modelos;

namespace API.Domain.Interfaces
{
    public interface IProfesorRepository
    {
        public IEnumerable<Profesor>GetProfesor();
    }
}
