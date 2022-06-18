using AccesData;
using Domain;
using Domain.EntitiesDTO;

namespace AccessData
{
    public interface IAlquileresRepository
    {
        public void AddAlquiler(Alquileres alquiler);
        public bool ValidarReserva(string dni, string isbn);
        public void UpdateReserva(string dni, string isbn);
        public List<DetalleAlquiler> GetAlquileres(int estado);
        public List<DetalleAlquiler> GetLibrosReservadosAlquilados(string dni, int estado);
    }

    public class AlquileresRepository : IAlquileresRepository
    {
        private readonly BibliotecaContext _context = new BibliotecaContext();
        public void AddAlquiler(Alquileres alquiler)
        {
            _context.Alquileres.Add(alquiler);
            _context.SaveChanges();
        }

        public bool ValidarReserva(string dni, string isbn)
        {
            var reserva = _context.Alquileres.FirstOrDefault(a => a.Cliente.DNI == dni && a.Libros_idx == isbn && a.Estado_idx == 1);
            if (reserva != null) { return true; }
            else return false;
        }



        public void UpdateReserva(string dni, string isbn)
        {
            var reserva = _context.Alquileres.FirstOrDefault(a => a.Cliente.DNI == dni && a.Libros_idx == isbn && a.Estado_idx == 1);
            reserva.FechaAlquiler = DateTime.Now;
            reserva.FechaDevolucion = DateTime.Now.AddDays(7);
            reserva.Estado_idx = 2;
            _context.SaveChanges();
        }

        public List<DetalleAlquiler> GetAlquileres(int estado)
        {
            var list = (from a in _context.Alquileres
                        join c in _context.Cliente on a.Cliente_idx equals c.ClienteID
                        join l in _context.Libros on a.Libros_idx equals l.ISBN
                        join e in _context.EstadoDeAlquileres on a.Estado_idx equals e.EstadoId
                        where a.Estado_idx == estado
                        select new DetalleAlquiler(new LibrosDTO2(l.ISBN, l.Titulo, l.Autor, l.Editorial, l.Edicion, l.Imagen), new ClienteDTO(c.DNI, c.Nombre, c.Apellido, c.Email), new EstadoDTO(e.EstadoId, e.Descripcion), a.FechaReserva, a.FechaAlquiler, a.FechaDevolucion)

                ).ToList();
            return list;
        }

        public List<DetalleAlquiler> GetLibrosReservadosAlquilados(string dni, int estado)
        {
            return (from l in _context.Libros
                    join a in _context.Alquileres on l.ISBN equals a.Libros_idx
                    join c in _context.Cliente on a.Cliente_idx equals c.ClienteID
                    join e in _context.EstadoDeAlquileres on a.Estado_idx equals e.EstadoId
                    where a.Estado_idx == estado && a.Cliente.DNI == dni
                    select new DetalleAlquiler(new LibrosDTO2(l.ISBN, l.Titulo, l.Autor, l.Editorial, l.Edicion, l.Imagen), new ClienteDTO(c.DNI, c.Nombre, c.Apellido, c.Email), new EstadoDTO(e.EstadoId, e.Descripcion), a.FechaReserva, a.FechaAlquiler, a.FechaDevolucion)
               ).ToList();
        }


    }
}
