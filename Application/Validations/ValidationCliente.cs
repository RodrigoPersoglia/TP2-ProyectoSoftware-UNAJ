using AccessData;

namespace Application.Validations
{
    public interface IValidationCliente
    {
        public bool ValidarCliente(string dni);
    }
    public class ValidationCliente : IValidationCliente
    {
        private readonly IClientesRepository _repository;
        public ValidationCliente(IClientesRepository repository)
        {
            _repository = repository;
        }

        public bool ValidarCliente(string dni)
        {
            return _repository.ValidarCliente(dni);
        }


    }
}
