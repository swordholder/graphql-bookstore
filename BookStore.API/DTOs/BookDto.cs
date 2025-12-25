using BookStore.API.Models;

namespace BookStore.API.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public AuthorDto Author { get; set; } = new AuthorDto();
        public Genre Genre { get; set; }
        public int PublishedYear { get; set; }

        public decimal Price { get; set; }
    }
}
