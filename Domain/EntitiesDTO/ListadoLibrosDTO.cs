namespace Domain.EntitiesDTO
{
    public class ListadoLibrosDTO
    {
        public LibrosDTO2 Libro { get; set; }
        public EstadoDTO Estado { get; set; }

        public ListadoLibrosDTO(LibrosDTO2 libro, EstadoDTO estado)
        {
            Libro = libro;
            Estado = estado;
        }
    }
}
