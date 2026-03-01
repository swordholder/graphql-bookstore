using BookStore.API.DataLoaders;
using BookStore.API.Mappers;

namespace BookStore.API.Models
{
    public class Book
    {
        private readonly AuthorMapper _authorMapper = new AuthorMapper();

        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        [GraphQLNonNullType]        
        public async Task<Author> Author([Service]AuthorDataLoader authorDataLoader)
        {          
            var authorDto = await authorDataLoader.LoadAsync(Id, CancellationToken.None);

            return _authorMapper.ToDomain(authorDto);            
        }

        public List<Author> CoAuthors { get; set; } = new List<Author>();
        public Genre Genre { get; set; }
        public int PublishedYear { get; set; }

        public decimal Price { get; set; }
    }
}
