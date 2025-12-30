using BookStore.API.DTOs;
using BookStore.API.Services;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Repositories
{
    public class AuthorRepository 
    {
        private readonly IDbContextFactory<BookStoreDbContext> _contextFactory;

        public AuthorRepository(IDbContextFactory<BookStoreDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<AuthorDto?> GetAuthorByIdAsync(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<AuthorDto> AddAuthorAsync(AuthorDto author)
        {
            await using var context = _contextFactory.CreateDbContext();
            context.Authors.Add(author);
            await context.SaveChangesAsync();
            return author;
        }

        public async Task<AuthorDto?> UpdateAuthorAsync(AuthorDto author)
        {
            await using var context = _contextFactory.CreateDbContext();
            var existingAuthor = await context.Authors.FindAsync(author.Id);
            if (existingAuthor == null)
            {
                return null;
            }
            existingAuthor.Name = author.Name;
            existingAuthor.Bio = author.Bio;
            await context.SaveChangesAsync();
            return existingAuthor;
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            await using var context = _contextFactory.CreateDbContext();
            var author = await context.Authors.FindAsync(id);

            if (author == null)
            {
                return false;
            }

            context.Authors.Remove(author);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<List<AuthorDto>> GetAllAuthorsAsync()
        {
            await using var context = _contextFactory.CreateDbContext();
            return await context.Authors.ToListAsync();
        }
    }
}
