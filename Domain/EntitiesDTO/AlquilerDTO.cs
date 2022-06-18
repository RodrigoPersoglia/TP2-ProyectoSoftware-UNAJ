namespace Domain.EntitiesDTO
{
    public class AlquilerDTO
    {
        public string clienteDNI { get; set; }
        public string isbn { get; set; }
        public DateTime? FechaAlquiler { get; set; }
        public DateTime? FechaReserva { get; set; }

    }
}
