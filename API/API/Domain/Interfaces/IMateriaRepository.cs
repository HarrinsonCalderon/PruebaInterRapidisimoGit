using API.Domain.Modelos;

namespace API.Domain.Interfaces
{
    public interface IMateriaRepository
    {
        public IEnumerable<Materia> ObtenerMateria();
       
    }
}
