using AccessData;
using Application.Validations;
using Domain.EntitiesDTO;
using Domain.Mappers;

namespace Application.Services
{
    public interface IAlquileresService
    {
        public Response AddAlquiler(AlquilerDTO alquiler);
        public Response UpdateAlquiler(ReservaDTO reserva);
        public Response GetAlquileres(int estado);
        public Response GetLibroReservadosAlquilados(string dni,int estado);

    }


    public class AlquileresService : IAlquileresService
    {
        private readonly IAlquileresRepository _repository;
        private readonly IClientesRepository _repositoryCliente;
        private readonly IValidationAlquiler _validacion;
        private readonly IValidationCliente _validacionCliente;
        private readonly IValidationLibro _validacionLibro;
        private readonly ILibrosService _service;

        public AlquileresService(IAlquileresRepository repository, IValidationAlquiler validacion, IValidationCliente validacionCliente, IValidationLibro validacionLibro, ILibrosService service, IClientesRepository repositoryCliente)
        {
            _repository = repository;
            _validacion = validacion;
            _validacionCliente = validacionCliente;
            _validacionLibro = validacionLibro;
            _service = service;
            _repositoryCliente = repositoryCliente;
        }

        public Response AddAlquiler(AlquilerDTO alquiler)
        {
            if (_validacionCliente.ValidarCliente(alquiler.clienteDNI) && _validacionLibro.ValidarLibro(alquiler.isbn))
            {
                if (alquiler.FechaAlquiler != null || alquiler.FechaReserva != null)
                {
                    if (alquiler.FechaAlquiler != null && alquiler.FechaReserva != null)
                    {
                        return new Response(400, new RespuestasDTO("Uno de los parámetros fechaAlquiler o fechaReserva debe ser null"));
                    }
                    else
                    {
                        if (_validacionLibro.ValidarStockLibro(alquiler.isbn))
                        {
                            alquiler.clienteDNI = _repositoryCliente.GetClienteID(alquiler.clienteDNI).ToString();
                            _repository.AddAlquiler(Mapper.AlquilerDtoToEntity(alquiler));
                            _service.DescontarStockLibro(alquiler.isbn);
                            return new Response(201, new RespuestasDTO("Operación confirmada"));

                        }
                        else return new Response(400, new RespuestasDTO("No hay stock del libro solicitado"));
                    }
                }
                else return new Response(400, new RespuestasDTO("Uno de los parámetros fechaAlquiler o fechaReserva debe ser una fecha válida"));
            }
            else return new Response(400, new RespuestasDTO("Eror en los datos ingresados. El cliente o el libro no existen"));
        }



        public Response UpdateAlquiler(ReservaDTO reserva)
        {
            if (_validacionCliente.ValidarCliente(reserva.clienteDNI) && _validacionLibro.ValidarLibro(reserva.isbn))
            {
                if (_validacion.ValidarReserva(reserva))
                {
                    _repository.UpdateReserva(reserva.clienteDNI, reserva.isbn);
                    return new Response(201, new RespuestasDTO("Alquiler registrado correctamente"));
                }
                else return new Response(400, new RespuestasDTO("El cliente no posee reservas del libro ingresado"));

            }
            else return new Response(400, new RespuestasDTO("Error en los datos ingresados. El cliente o el libro no existen"));
        }


        public Response GetAlquileres(int estado)
        {
            if (estado < 4)
            {
                return new Response(200, _repository.GetAlquileres(estado));
            }
            else return new Response(400, new RespuestasDTO("No se puede resolver la petición. Los valores permitidos son 1,2 o 3"));

        }

        public Response GetLibroReservadosAlquilados(string dni, int estado)
        {
            if (_validacionCliente.ValidarCliente(dni))
            {
                if(estado>0 && estado < 3) { return new Response(200, _repository.GetLibrosReservadosAlquilados(dni,estado)); }
                return new Response(400, new RespuestasDTO("El estado ingresado no es valido. Los estados válidos son 1) reservas , 2) alquileres"));
            }
            else return new Response(400, new RespuestasDTO("El cliente ingresado no existe"));
        }

    }
}
