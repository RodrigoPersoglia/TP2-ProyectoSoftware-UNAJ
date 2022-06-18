namespace Domain.EntitiesDTO
{
    public class DetalleAlquiler
    {
        public DateTime? FechaReserva { get; set; }
        public DateTime? FechaAlquiler { get; set; }
        public DateTime? FechaDevolucion { get; set; }

        public LibrosDTO2 Libro { get; set; }
        public ClienteDTO Cliente { get; set; }
        public EstadoDTO Estado { get; set; }

        public DetalleAlquiler(LibrosDTO2 libro, ClienteDTO cliente, EstadoDTO estado, DateTime? fechaReserva, DateTime? fechaAlquiler, DateTime? fechaDevolucion)
        {
            Libro = libro;
            Cliente = cliente;
            Estado = estado;
            FechaAlquiler = fechaAlquiler;
            FechaDevolucion = fechaDevolucion;
            FechaReserva = fechaReserva;

        }
    }


}
