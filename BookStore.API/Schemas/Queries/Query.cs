
using BookStore.API.Models;

namespace BookStore.API.Schemas.Queries
{
    public class Query
    {
        // Exposes a GraphQL field named "books"
        [GraphQLName("books")]
        public List<Book> GetBooks()
        {
            return GenerateBooks();
        }

        // Exposes a GraphQL field named "book" that takes an `id` argument
        [GraphQLName("book")]
        public async Task<Book?> GetBook(int id)
        {
            var books = GenerateBooks();
            await Task.Delay(500); // simulate async work
            var book = books.FirstOrDefault(b => b.Id == id);

            return book;
        }

        private List<Book> GenerateBooks()
        {
            return new List<Book>
            {
                new Book
                {
                    Id = 1,
                    Title = "The Great Gatsby",
                    Author = new Author { Id = 1, Name = "F. Scott Fitzgerald", Bio = "American novelist and short story writer." },
                    Genre = Genre.Fiction,
                    PublishedYear = 1925,
                    Price = 10.99m
                },
                new Book
                {
                    Id = 2,
                    Title = "1984",
                    Author = new Author { Id = 2, Name = "George Orwell", Bio = "English novelist and essayist." },
                    Genre = Genre.ScienceFiction,
                    PublishedYear = 1949,
                    Price = 8.99m
                },
                new Book
                {
                    Id = 3,
                    Title = "To Kill a Mockingbird",
                    Author = new Author { Id = 3, Name = "Harper Lee", Bio = "American novelist widely known for To Kill a Mockingbird." },
                    Genre = Genre.Fiction,
                    PublishedYear = 1960,
                    Price = 12.99m
                },
                new Book
                {
                    Id = 4,
                    Title = "War and Piece",
                    Author = new Author { Id = 4, Name = "Leo Tolstoy", Bio = "One of the novelists of 19th century" },
                    Genre = Genre.Fiction,
                    PublishedYear = 1890,
                    Price = 13.99m
                },
            };
        }
    }
}
