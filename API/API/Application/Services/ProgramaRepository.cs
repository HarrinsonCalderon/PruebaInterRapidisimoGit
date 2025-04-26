using API.Application.Interfaces;
using API.Data.Repositorio;
using API.Domain.Interfaces;
using API.Domain.Modelos;

namespace API.Application.Services
{
    public class ProgramaService : IProgramaService
    {
        private readonly ProgramaRepository _Repository;

        public ProgramaService()
        {
            _Repository = new ProgramaRepository();   
        }

        public IEnumerable<Programa> GetPrograma()
        {
           return _Repository.GetPrograma();    
        }
    }
}
