

using API.Domain.Modelos;

namespace API.Application.Interfaces
{
    public interface IProfesorService
    {
        public IEnumerable<Profesor> GetProfesor();
    }
}
