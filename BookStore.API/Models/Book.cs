namespace BookStore.API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Author Author { get; set; } = new Author();

        public List<Author> CoAuthors { get; set; } = new List<Author>();
        public Genre Genre { get; set; }
        public int PublishedYear { get; set; }

        public decimal Price { get; set; }
    }
}
