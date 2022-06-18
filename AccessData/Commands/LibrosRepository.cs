
using AccesData;
using Domain;
using Domain.EntitiesDTO;

namespace AccessData
{
    public interface ILibrosRepository
    {

        public List<Libros> GetLibrosDisponibles();
        public Libros GetByIdLibro(string id);
        public bool ValidarLibro(string isbn);
        public int? StockLibro(string isbn);
        public bool ValidarStockLibro(string isbn);
        public void DescontarStockLibro(string isbn);
        public List<LibrosDTO> GetAllLibros();
        public List<Libros> GetLibros(bool? stock = null, string? nombre = null, string? titulo = null);

    }

    public class LibrosRepository : ILibrosRepository
    {

        private static readonly BibliotecaContext _context = new BibliotecaContext();

        public List<Libros> GetLibrosDisponibles()
        {
            return _context.Libros.Where(l => l.Stock > 0).ToList();
        }


        public Libros GetByIdLibro(string id)
        {
            return _context.Libros.FirstOrDefault(l => l.ISBN == id);
        }


        public bool ValidarLibro(string isbn)
        {
            if (_context.Libros.Find(isbn) != null) { return true; }
            else return false;
        }


        public int? StockLibro(string isbn)
        {
            Libros libro = _context.Libros.FirstOrDefault(l => l.ISBN == isbn);
            return libro.Stock;
        }


        public bool ValidarStockLibro(string isbn)
        {
            if (_context.Libros.Find(isbn).Stock > 0) { return true; }
            else return false;
        }


        public void DescontarStockLibro(string isbn)
        {
            Libros libro = _context.Libros.Find(isbn);
            libro.Stock -= 1;
            _context.SaveChanges();
        }

        public List<LibrosDTO> GetAllLibros()
        {
            var list = (from l in _context.Libros
                        select new LibrosDTO(l.ISBN, l.Titulo, l.Autor, l.Editorial, l.Edicion, l.Stock, l.Imagen)
                ).ToList();
            return list;
        }


        public List<Libros> GetLibros(bool? stock = null, string? nombre = null, string? titulo = null)
        {
            if (stock == null)
            {
                return _context.Libros.Where(libro => (string.IsNullOrEmpty(nombre) || libro.Autor.Contains(nombre)) &&
               (string.IsNullOrEmpty(titulo) || libro.Titulo.Contains(titulo))).ToList();
            }

            else if (stock.Value)
            {
                return _context.Libros.Where(libro => (string.IsNullOrEmpty(nombre) || libro.Autor.Contains(nombre)) && libro.Stock > 0 &&
                                            (string.IsNullOrEmpty(titulo) || libro.Titulo.Contains(titulo))).ToList();
            }

            else
            {
                return _context.Libros.Where(libro => (string.IsNullOrEmpty(nombre) || libro.Autor.Contains(nombre)) && libro.Stock == 0 &&
                               (string.IsNullOrEmpty(titulo) || libro.Titulo.Contains(titulo))).ToList();
            }
        }



    }
}
