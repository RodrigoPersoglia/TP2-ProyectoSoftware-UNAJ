using AccessData;
using Application.Validations;
using Domain;
using Domain.EntitiesDTO;
using Domain.Mappers;

namespace Application.Services
{
    public interface ILibrosService
    {
        public List<Libros> GetLibrosDisponibles();
        public Response StockLibro(string isbn);
        public void DescontarStockLibro(string isbn);
        public Response GetLibros(bool? stock = null, string? nombre = null, string? titulo = null);

    }

    public class LibrosService : ILibrosService
    {
        public readonly ILibrosRepository _repository;
        public readonly IValidationLibro _validacion;
        public LibrosService(ILibrosRepository repository,IValidationLibro validacion)
        {
            _repository = repository;
            _validacion = validacion;
        }


        public List<Libros> GetLibrosDisponibles()
        {
            return _repository.GetLibrosDisponibles();
        }

        public Response StockLibro(string isbn)
        {
            if (_validacion.ValidarLibro(isbn))
            {
                return new Response(200, new StockLibroDTO(isbn, _repository.StockLibro(isbn)));
            }
            else return new Response(400, new RespuestasDTO("El libro no existe"));
        }

        public void DescontarStockLibro(string isbn)
        {
            _repository.DescontarStockLibro(isbn);
        }

        public Response GetLibros(bool? stock = null, string? nombre = null, string? titulo = null)
        {
            return new Response(200, Mapper.ListLibroToLibroDTO(_repository.GetLibros(stock, nombre, titulo)));
        }


    }
}
