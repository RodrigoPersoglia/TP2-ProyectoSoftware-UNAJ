namespace Domain.EntitiesDTO
{
    public class StockLibroDTO
    {
        public string Isbn { get; set; }
        public int? Stock { get; set; }

        public StockLibroDTO(string isbn, int? stock)
        {
            Isbn = isbn;
            Stock = stock;
        }
    }
}
