using API.Application.Interfaces;
using API.Data.Repositorio;
using API.Domain.Interfaces;
using API.Domain.Modelos;

namespace API.Application.Services
{
    public class MateriaService : IMateriaService
    {
        private readonly MateriaRepository _Repository;

        public MateriaService()
        {
            _Repository = new MateriaRepository();   
        }

        public IEnumerable<Materia> ObtenerMateria()
        {
            return _Repository.ObtenerMateria();
        }

        
    }
}
