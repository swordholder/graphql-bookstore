using BookStore.API.DataLoaders;
using BookStore.API.DTOs;
using BookStore.API.Models;

namespace BookStore.API.Mappers
{
    public class BookMapper
    {
        private readonly AuthorDataLoader _authorDataLoader;

        public BookMapper(AuthorDataLoader authorDataLoader) 
        {
            _authorDataLoader = authorDataLoader;
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
            var book = new Book(_authorDataLoader)
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
