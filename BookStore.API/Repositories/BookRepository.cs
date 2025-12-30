using BookStore.API.DTOs;
using BookStore.API.Services;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class BookRepository
    {
        private readonly IDbContextFactory<BookStoreDbContext> _contextFactory;

        public BookRepository(IDbContextFactory<BookStoreDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Books.ToListAsync();
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Books.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<BookDto> AddBookAsync(BookDto book)
        {
            await using var context = _contextFactory.CreateDbContext();
            context.Books.Add(book);
            await context.SaveChangesAsync();
            return book;
        }

        public async Task<BookDto?> UpdateBookAsync(BookDto book)
        {
            await using var context = _contextFactory.CreateDbContext();
            var existingBook = await context.Books.FindAsync(book.Id);
            if (existingBook == null)
            {
                return null;
            }
            existingBook.Title = book.Title;
            existingBook.Genre = book.Genre;
            existingBook.PublishedYear = book.PublishedYear;
            existingBook.Author = book.Author;
            existingBook.Price = book.Price;
            await context.SaveChangesAsync();
            return existingBook;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var book = await context.Books.FindAsync(id);

            if (book == null)
            {
                return false;
            }
            context.Books.Remove(book);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
