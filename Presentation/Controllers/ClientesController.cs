using Application.Services;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClientesController(IClienteService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult AddCliente([FromBody] ClienteDTO cliente)
        {
            try
            {
                var response = _service.AddCliente(cliente);
                return StatusCode(response.CodigoEstado, response.Json);
            }
            catch (Exception) { return StatusCode(500, "Internal Server Error"); }
        }


        [HttpGet]
        public IActionResult GetCliente(string? nombre = null, string? apellido = null, string? dni = null)
        {
            try
            {
                var response = _service.GetCliente(nombre, apellido, dni);
                return StatusCode(response.CodigoEstado, response.Json);
            }
            catch (Exception) { return StatusCode(500, "Internal Server Error"); }
        }



    }
}
