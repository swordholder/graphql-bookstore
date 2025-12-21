using BookStore.API.Models;
using BookStore.API.Schemas;

namespace BookStore.API.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AuthorDto Author { get; set; }
        public Genre Genre { get; set; }
        public int PublishedYear { get; set; }

        public decimal Price { get; set; }

        public IEnumerable<AuthorDto> CoAuthors { get; set; }
    }
}
