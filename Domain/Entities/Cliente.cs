using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Cliente
    {
        [Key]
        public int ClienteID { get; set; }
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Alquileres> Alquileres { get; set; }


        public override string ToString()
        {
            if (ClienteID > 0)
            {
                return "Nº de Cliente: " + ClienteID.ToString() + ", DNI: " + DNI + ", Nombre: " + Nombre + ", Apellido: " + Apellido + ", Email: " + Email;
            }
            else { return "DNI: " + DNI + ", Nombre: " + Nombre + ", Apellido: " + Apellido + ", Email: " + Email; }

        }

    }
}
