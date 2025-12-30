using BookStore.API.DTOs;
using BookStore.API.Models;
using BookStore.API.Repositories;

namespace BookStore.API.Mappers
{
    public class BookMapper
    {
        private readonly AuthorRepository _authorRepository;

        public BookMapper(AuthorRepository authorRepository) 
        {
            _authorRepository = authorRepository;
        }

        public async Task<BookDto> ToDto(Book book) 
        {
           var bookDto = new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                PublishedYear = book.PublishedYear,
                Price = book.Price                
            };            

            if (book.Author != null)         
            {
                bookDto.Author = new AuthorDto
                {
                    Id = book.Author.Id,
                    Name = book.Author.Name,
                    Bio = book.Author.Bio
                };
            }            
            
            return bookDto;
        }

        public Book ToModel(BookDto bookDto) 
        {
            var book = new Book(_authorRepository)
            {
                Id = bookDto.Id,
                Title = bookDto.Title,
                Genre = bookDto.Genre,
                PublishedYear = bookDto.PublishedYear,
                Price = bookDto.Price                
            };

            if(bookDto.Author != null)         
            {
                book.Author = new Author
                {
                    Id = bookDto.Author.Id,
                    Name = bookDto.Author.Name,
                    Bio = bookDto.Author.Bio
                };
            }            
            
            return book;
        }

        public AuthorDto ToDtoAuthor(Author author)
        {
            return new AuthorDto
            {
                Id = author.Id,
                Name = author.Name,
                Bio = author.Bio
            };
        }
    }
}
