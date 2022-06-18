using AccessData;

namespace Application.Validations
{
    public interface IValidationLibro
    {
        public bool ValidarLibro(string isbn);
        public bool ValidarStockLibro(string isbn);
    }

    public class ValidationLibro : IValidationLibro
    {
        private readonly ILibrosRepository _repository;
        public ValidationLibro(ILibrosRepository repository)
        {
            _repository = repository;
        }

        public bool ValidarLibro(string isbn)
        {
            return _repository.ValidarLibro(isbn);
        }

        public bool ValidarStockLibro(string isbn)
        {
            return _repository.ValidarStockLibro(isbn);
        }



    }
}
