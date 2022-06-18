namespace Domain.EntitiesDTO
{
    public class LibrosDTO2
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Edicion { get; set; }
        public string Imagen { get; set; }

        public LibrosDTO2(string isbn, string titulo, string autor, string editorial, string edicion, string imagen)
        {
            ISBN = isbn;
            Titulo = titulo;
            Autor = autor;
            Editorial = editorial;
            Edicion = edicion;
            Imagen = imagen;
        }

        public LibrosDTO2() { }

    }
}
