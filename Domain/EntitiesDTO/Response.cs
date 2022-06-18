namespace Domain.EntitiesDTO
{
    public class Response
    {
        public int CodigoEstado { get; set; }
        public object Json { get; set; }

        public Response(int codigoEstado, object json)
        {
            CodigoEstado = codigoEstado;
            Json = json;
        }
    }
}
