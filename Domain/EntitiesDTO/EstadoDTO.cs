namespace Domain.EntitiesDTO
{
    public class EstadoDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public EstadoDTO(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
    }

}
