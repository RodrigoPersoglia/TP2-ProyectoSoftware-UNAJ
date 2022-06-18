using System.ComponentModel.DataAnnotations;
namespace Domain
{
    public class Alquileres
    {
        [Key]
        public int Id { get; set; }
        public virtual Cliente Cliente { get; set; }
        public int Cliente_idx { get; set; }
        public virtual Libros Libros { get; set; }
        public string Libros_idx { get; set; }
        public virtual EstadoDeAlquileres Estado { get; set; }
        public int Estado_idx { get; set; }
        public DateTime? FechaAlquiler { get; set; }
        public DateTime? FechaReserva { get; set; }
        public DateTime? FechaDevolucion { get; set; }



    }
}
