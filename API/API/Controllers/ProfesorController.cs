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
    [Route("api/profesor")]
    public class ProfesorController : ControllerBase
    {

        private readonly IProfesorService _profesorService;
        private readonly Ijemplo _ijemplo;
         
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public ProfesorController(IProfesorService profesorService, Ijemplo ijemplo)
        {
            _profesorService=profesorService;
            _ijemplo=ijemplo;
            
        }


        [HttpGet]
        public IEnumerable<ProfesorDTO> ObtenerProfesor()
        {
            var lista = _profesorService.GetProfesor().Select(e=> (Mapear.MapearPersonaAPersonaDTO(e)));
            //return lista;
            return lista.ToList();
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{




        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //[HttpGet]
        //public string Obtener2()
        //{

        //    return _ijemplo.Obtener();
        //}

    }
}
