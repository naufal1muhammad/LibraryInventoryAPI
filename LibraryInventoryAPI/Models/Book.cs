namespace LibraryInventoryAPI.Models
{
    public class Book
    {
        public int Id { get; set; } // Unique ID for each book
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int YearPublished { get; set; }
        public string Genre { get; set; } = string.Empty;
        public bool IsAvailable { get; set; } = true; // True = in stock
    }
}
