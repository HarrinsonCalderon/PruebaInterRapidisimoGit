using API.Domain.Modelos;

namespace API.Domain.Interfaces
{
    public interface IProgramaRepository
    {
        public IEnumerable<Programa>GetPrograma();
    }
}
