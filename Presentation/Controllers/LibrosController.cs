using Application.Services;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Controllers
{
    [Route("api/libros")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ILibrosService _service;

        public LibrosController(ILibrosService service)
        {
            _service = service;
        }


        [HttpGet("{id}")]
        public IActionResult GetListado(string id)
        {
            try
            {
                Response response = _service.StockLibro(id);
                return StatusCode(response.CodigoEstado, response.Json);
            }
            catch (Exception) { return StatusCode(500, "Internal Server Error"); }
        }


        [HttpGet]
        public IActionResult GetLibros(bool? stock = null, string? nombre = null, string? titulo = null)
        {
            try
            {
                Response response = _service.GetLibros(stock, nombre, titulo);
                return StatusCode(response.CodigoEstado, response.Json);
            }
            catch (Exception) { return StatusCode(500, "Internal Server Error"); }
        }


    }
}
