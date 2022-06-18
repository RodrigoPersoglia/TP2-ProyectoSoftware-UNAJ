namespace Domain.EntitiesDTO
{
    public class RespuestasDTO
    {
        public string Mensaje { get; set; }

        public RespuestasDTO(string mensaje)
        {
            Mensaje = mensaje;
        }
    }
}
