
using Application.Services;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Controllers
{
    [Route("api/alquiler")]
    [ApiController]

    public class AlquileresController : ControllerBase
    {
        private readonly IAlquileresService _service;
        public AlquileresController(IAlquileresService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddAlquiler([FromBody] AlquilerDTO alquiler)
        {
            try
            {
                var response = _service.AddAlquiler(alquiler);
                return StatusCode(response.CodigoEstado, response.Json);
            }
            catch (Exception) { return StatusCode(500, "Internal Server Error"); }
        }


        [HttpPut]
        public IActionResult ReservaToAlquiler([FromBody] ReservaDTO reservaDTO)
        {
            try
            {
                var response = _service.UpdateAlquiler(reservaDTO);
                return StatusCode(response.CodigoEstado, response.Json);
            }
            catch (Exception) { return StatusCode(500, "Internal Server Error"); }
        }


        [HttpGet]
        public IActionResult GetListado(int estado)
        {
            try
            {
                var response = _service.GetAlquileres(estado);
                return StatusCode(response.CodigoEstado, response.Json);
            }
            catch (Exception) { return StatusCode(500, "Internal Server Error"); }
        }


        [HttpGet("cliente/{id}")]
        public IActionResult GetListadoReservaAlquiler(string id,int estado)
        {
            try
            {
                var response = _service.GetLibroReservadosAlquilados(id,estado);
                return StatusCode(response.CodigoEstado, response.Json);
            }
            catch (Exception) { return StatusCode(500, "Internal Server Error"); }
        }

    }
}
