using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Libros
    {
        [Key]
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Edicion { get; set; }
        public int? Stock { get; set; }
        public string Imagen { get; set; }


        public virtual ICollection<Alquileres> Alquileres { get; set; }
        public override string ToString()
        {
            return "Titulo: " + Titulo + ", Autor: " + Autor + ", Editorial: " + Editorial + ", Edición: " + Edicion + ", ISBN: " + ISBN + ", Stock: " + Stock.ToString();
        }

    }
}