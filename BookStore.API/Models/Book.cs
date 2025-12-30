using BookStore.API.Mappers;
using BookStore.API.Repositories;

namespace BookStore.API.Models
{
    public class Book
    {
        private readonly AuthorMapper _authorMapper = new AuthorMapper();
        private readonly AuthorRepository _authorRepository;

        public Book(AuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        [GraphQLNonNullType]
        public Author Author
        {
            get { return FetchAuthor(_authorRepository).Result;}
            set;
        }
        
        private async Task<Author> FetchAuthor(AuthorRepository authorRepository)
        {          
            var authorDto = await authorRepository.GetAuthorByIdAsync(this.Id);

            return _authorMapper.ToDomain(authorDto);            
        }

        public List<Author> CoAuthors { get; set; } = new List<Author>();
        public Genre Genre { get; set; }
        public int PublishedYear { get; set; }

        public decimal Price { get; set; }
    }
}
