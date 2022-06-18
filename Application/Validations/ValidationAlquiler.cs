using AccessData;
using Domain.EntitiesDTO;

namespace Application.Validations
{

    public interface IValidationAlquiler
    {
        public bool ValidarReserva(ReservaDTO reserva);
    }


    public class ValidationAlquiler : IValidationAlquiler
    {
        private readonly IAlquileresRepository _repository2;

        public ValidationAlquiler(IAlquileresRepository repository)
        {
            _repository2 = repository;
        }

        public bool ValidarReserva(ReservaDTO reserva)
        {
            return _repository2.ValidarReserva(reserva.clienteDNI, reserva.isbn);
        }

    }

}
