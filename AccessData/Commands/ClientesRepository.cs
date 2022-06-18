using AccesData;
using Domain;
using Domain.Exceptions;

namespace AccessData
{
    public interface IClientesRepository
    {
        public void CreateCliente(Cliente cliente);
        public bool ValidarCliente(string dni);
        public List<Cliente> GetCliente(string? nombre = null, string? apellido = null, string? dni = null);
        int GetClienteID(string dni);
    }


    public class ClientesRepository : IClientesRepository
    {
        private static readonly BibliotecaContext _context = new BibliotecaContext();

        public void CreateCliente(Cliente cliente)
        {
            if ((_context.Cliente.Where(c => c.DNI == cliente.DNI)).Count()>0) { throw new ExisteException("El dni ingresado ya se encuentra registrado");}
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
        }

        public bool ValidarCliente(string dni)
        {
            if (_context.Cliente.FirstOrDefault(c => c.DNI == dni) != null) { return true; }
            else return false;
        }

        public List<Cliente> GetCliente(string? nombre = null, string? apellido = null, string? dni = null)
        {
            return _context.Cliente.
                                    Where(cliente => (string.IsNullOrEmpty(nombre) || cliente.Nombre == nombre) &&
                                    (string.IsNullOrEmpty(apellido) || cliente.Apellido == apellido) &&
                                    (string.IsNullOrEmpty(dni) || cliente.DNI == dni)).ToList();
        }

        public int GetClienteID(string dni)
        {
           return _context.Cliente.Where(c => c.DNI == dni).FirstOrDefault().ClienteID;
        }

    }


}
