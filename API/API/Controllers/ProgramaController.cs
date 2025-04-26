using API.Application.Interfaces;
using API.Application.ModelosDTO;
using API.Application.Services;
using API.Application.Utilidades;
using API.Data.Repositorio;
using API.Domain.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/programa")]
    public class ProgramaController : ControllerBase
    {
        private readonly IProgramaService _programaService;



        public ProgramaController(IProgramaService IProgramaService  )
        {
            _programaService = IProgramaService;
            
            
        }


        [HttpGet("GetPrograma")]
        public IEnumerable<ProgramaDTO> ObtenerPrograma()
        {
            var lista = _programaService.GetPrograma().Select(e=> (Mapear.MapearProgramaAProgramaDTO(e)));
            //return lista;
            return lista.ToList();
        }

        
    }
}
