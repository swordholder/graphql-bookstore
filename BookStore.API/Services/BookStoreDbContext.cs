using BookStore.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Services
{
    public class BookStoreDbContext : DbContext
    {
         public DbSet<AuthorDto> Authors { get; set; }
         public DbSet<BookDto> Books { get; set; }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options)
        {
        }

    }
}
