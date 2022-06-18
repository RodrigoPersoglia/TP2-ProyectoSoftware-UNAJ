using AccessData;
using Domain.EntitiesDTO;
using Domain.Exceptions;
using Domain.Mappers;

namespace Application.Services
{
    public interface IClienteService
    {
        public Response AddCliente(ClienteDTO clienteDto);
        public Response GetCliente(string? nombre = null, string? apellido = null, string? dni = null);
    }


    public class ClienteService : IClienteService
    {

        private readonly IClientesRepository _repository;
        public ClienteService(IClientesRepository repository)
        {
            _repository = repository;
        }

        public Response AddCliente(ClienteDTO clienteDto)
        {
            try
            {
                if (clienteDto != null)
                {
                    _repository.CreateCliente(Mapper.ClienteDtoToEntity(clienteDto));
                    return new Response(201, new RespuestasDTO("Cliente Creado correctamente"));
                }
                else return new Response(400, new RespuestasDTO("Los datos recibidos por parámetro son incorrectos"));
            }
            catch (ExisteException ex) { return new Response(400, new RespuestasDTO(ex.Message)); }

        }

        public Response GetCliente(string? nombre = null, string? apellido = null, string? dni = null)
        {
            return new Response(200, Mapper.ListClienteToCLienteDTO(_repository.GetCliente(nombre, apellido, dni)));
        }


    }
}
