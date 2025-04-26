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
    [Route("api/materia")]
    public class MateriaController : ControllerBase
    {
        private readonly IMateriaService _materiaService;



        public MateriaController(IMateriaService  Service)
        {
            _materiaService =  Service;
        }


        [HttpGet("GetMateria")]
        public IEnumerable<MateriaDTO> ObtenerMateria()
        {
            var lista = _materiaService.ObtenerMateria().Select(e=> (Mapear.MapearMateriaAMateriaDTO(e)));
            //return lista;
            return lista;
        }

        
            
            
        }

    }
 