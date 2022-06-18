using Domain.EntitiesDTO;

namespace Domain.Mappers
{
    public class Mapper
    {
        public static Cliente ClienteDtoToEntity(ClienteDTO clienteDto)
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = clienteDto.Nombre;
            cliente.Apellido = clienteDto.Apellido;
            cliente.DNI = clienteDto.DNI;
            cliente.Email = clienteDto.Email;
            return cliente;
        }

        public static List<ClienteDTO> ListClienteToCLienteDTO(List<Cliente> clientes)
        {
            var lista = new List<ClienteDTO>();
            foreach (Cliente cli in clientes)
            {
                lista.Add(EntityToClienteDTO(cli));
            }

            return lista;
        }

        public static ClienteDTO EntityToClienteDTO(Cliente cliente)
        {
            ClienteDTO clienteDTO = new ClienteDTO();
            clienteDTO.Nombre = cliente.Nombre;
            clienteDTO.Apellido = cliente.Apellido;
            clienteDTO.DNI = cliente.DNI;
            clienteDTO.Email = cliente.Email;
            return clienteDTO;
        }


        public static Alquileres AlquilerDtoToEntity(AlquilerDTO alquilerDto)
        {
            Alquileres alquiler = new Alquileres();

            alquiler.Cliente_idx= int.Parse(alquilerDto.clienteDNI);
            alquiler.Libros_idx = alquilerDto.isbn;
            if (alquilerDto.FechaAlquiler != null)
            {
                alquiler.Estado_idx = 2;
                alquiler.FechaDevolucion = ((DateTime)alquilerDto.FechaAlquiler).AddDays(7);
            }
            else { alquiler.Estado_idx = 1; }
            alquiler.FechaAlquiler = alquilerDto.FechaAlquiler;
            alquiler.FechaReserva = alquilerDto.FechaReserva;
            return alquiler;
        }

        public static LibrosDTO EntityToLibroDTO(Libros libro)
        {
            var libroDTO = new LibrosDTO();
            libroDTO.Autor = libro.Autor;
            libroDTO.Edicion = libro.Edicion;
            libroDTO.Editorial = libro.Editorial;
            libroDTO.ISBN = libro.ISBN;
            libroDTO.Imagen = libro.Imagen;
            libroDTO.Titulo = libro.Titulo;
            libroDTO.Stock = libro.Stock;
            return libroDTO;
        }

        public static List<LibrosDTO> ListLibroToLibroDTO(List<Libros> libros)
        {
            var lista = new List<LibrosDTO>();
            foreach (Libros li in libros)
            {
                lista.Add(EntityToLibroDTO(li));
            }
            return lista;
        }

    }
}
