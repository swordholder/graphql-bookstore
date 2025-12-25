using BookStore.API.Mappers;
using BookStore.API.Models;
using BookStore.API.Repositories;

namespace BookStore.API.Schemas.Queries
{
    public class Query
    {
        private readonly BookRepository _booksRepo;
        private readonly BookMapper _bookMapper;

        public Query(BookRepository bookRepository)
        {
            _booksRepo = bookRepository;
            _bookMapper = new BookMapper();
        }        

        // Exposes a GraphQL field named "book" that takes an `id` argument
        [GraphQLName("book")]
        public async Task<Book?> GetBook(int id)
        {
            var book = await _booksRepo.GetBookByIdAsync(id);

            if(book!=null)
                return _bookMapper.ToModel(book);

            return null;
        }

        // Exposes a GraphQL field named "books" that returns a list of all books
        [GraphQLName("books")]
        public async Task<List<Book>> GetBooks()
        {
            var books = await _booksRepo.GetAllBooksAsync();
            return books.Select(b => _bookMapper.ToModel(b)).ToList();
        }
    }
}
