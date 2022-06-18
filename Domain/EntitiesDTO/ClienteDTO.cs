namespace Domain.EntitiesDTO
{
    public class ClienteDTO
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        public ClienteDTO() { }
        public ClienteDTO(string dni, string nombre, string apellido, string email)
        {
            DNI = dni;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
        }

    }

}