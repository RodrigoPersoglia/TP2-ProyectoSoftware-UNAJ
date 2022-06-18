namespace Domain.EntitiesDTO
{
    public class LibrosDTO
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Edicion { get; set; }
        public int? Stock { get; set; }
        public string Imagen { get; set; }

        public LibrosDTO(string isbn, string titulo, string autor, string editorial, string edicion, int? stock, string imagen)
        {
            ISBN = isbn;
            Titulo = titulo;
            Autor = autor;
            Editorial = editorial;
            Edicion = edicion;
            Stock = stock;
            Imagen = imagen;
        }

        public LibrosDTO() { }

    }

}
