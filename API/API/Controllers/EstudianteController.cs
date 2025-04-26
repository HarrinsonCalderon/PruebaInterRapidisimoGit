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
    [Route("api/estudiante")]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;



        public EstudianteController(IEstudianteService IEstudianteService)
        {
            _estudianteService = IEstudianteService;
        }




        [HttpGet("GetEstudiantePrograma")]
        public IEnumerable<EstudianteProgramaDTO> ObtenerEstudiantePrograma(string? id = null)
        {
            var lista = _estudianteService.GetEstudiantePrograma( id ).Select(e => (Mapear.MapearEstudianteAEstudianteDTO(e)));
            //return lista;
            return lista.ToList();
        }


        [HttpPost("DeleteEstudiante")]
        public IActionResult DeleteEstudiante([FromBody] EstudianteActualizacionDTO e)
        {
            try {
                 
                _estudianteService.DeleteEstudiant( (e.Id.ToString()));

                return Ok("1");

            } catch (Exception ea )
            {
                return NoContent();

            }
           
            //return lista;
             
        }






        [HttpGet("GetEstudiantClase")]
        public IEnumerable<EstudianteClaseDTO> GetEstudianteClase(string? id = null)
        {
            var lista = _estudianteService.GetEstudianteClase(id).Select(e => (Mapear.MapearEstudianteClaseDTOEstudianteClase(e)));
            //return lista;
            return lista.ToList();
        }


        [HttpGet]
        public IEnumerable<EstudianteDTO> ObtenerProfesor()
        {
            var lista = _estudianteService.GetEstudiante().Select(e=> (Mapear.MapearEstudianteAEstudianteDTO(e)));
            //return lista;
            return lista.ToList();
        }

        [HttpPost("PostEstudiante")]
        public IActionResult PostEstudiante([FromBody] EstudianteCreacionDTO e)
        {
            try
            {

                EstudianteCreacion estudiante = new EstudianteCreacion();
                estudiante.Nombre = e.Nombre;
                estudiante.fkidprograma = e.fkidprograma;
                estudiante.materia=e.materia;

                _estudianteService.PostEstudiante(estudiante);
                return Ok("1");
            }
            catch (Exception ea)
            {
                return NoContent();
            }
             
            
            
        }


        [HttpPost("PostEstudianteActualizar")]
        public IActionResult ActualizacionEstudiante([FromBody] EstudianteActualizacionDTO e)
        {
            try
            {

                EstudianteActualizacion estudiante = new EstudianteActualizacion();
                estudiante.Id=e.Id;
                estudiante.Nombre = e.Nombre;
                estudiante.fkidprograma = e.fkidprograma;
                estudiante.materia = e.materia;
                estudiante.estudiantemateria=e.estudiantemateria;

                _estudianteService.PostEstudianteActualizar(estudiante);
                return Ok("1");
            }
            catch (Exception ea)
            {
                return NoContent();
            }



        }

    }
}
