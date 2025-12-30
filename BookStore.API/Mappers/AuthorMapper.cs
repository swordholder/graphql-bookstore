using BookStore.API.DTOs;
using BookStore.API.Models;

namespace BookStore.API.Mappers
{
    public class AuthorMapper
    {
        public Author ToDomain(AuthorDto authorDto)
        { 
           return new Author
           {
               Id = authorDto.Id,
               Name = authorDto.Name,
               Bio = authorDto.Bio
           };
        }

        public AuthorDto ToDto(Author author)
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
