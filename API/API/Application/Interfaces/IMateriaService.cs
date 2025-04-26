

using API.Domain.Modelos;

namespace API.Application.Interfaces
{
    public interface IMateriaService
    {
        public IEnumerable<Materia> ObtenerMateria();
     }
}
