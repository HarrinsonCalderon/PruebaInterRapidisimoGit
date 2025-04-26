using API.Application.Interfaces;
using API.Data.Repositorio;
using API.Domain.Interfaces;
using API.Domain.Modelos;

namespace API.Application.Services
{
    public class ProfesorService : IProfesorService
    {
        private readonly ProfesorRepository _Repository;

        public ProfesorService()
        {
            _Repository = new ProfesorRepository();   
        }

        public IEnumerable<Profesor> GetProfesor()
        {
            return _Repository.GetProfesor();
        }
    }
}
