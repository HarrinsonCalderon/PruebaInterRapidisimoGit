

using API.Domain.Modelos;

namespace API.Application.Interfaces
{
    public interface IProgramaService
    {
        public IEnumerable<Programa> GetPrograma();
    }
}
