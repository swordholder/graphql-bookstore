using BookStore.API.DTOs;
using BookStore.API.Repositories;

namespace BookStore.API.DataLoaders
{
    public class AuthorDataLoader : BatchDataLoader<int, AuthorDto>
    {
        private readonly AuthorRepository _authorRepository;

        public AuthorDataLoader(AuthorRepository authorRepository, IBatchScheduler batchScheduler, DataLoaderOptions options) : base(batchScheduler, options)
        {
            _authorRepository = authorRepository;
        }

        protected async override Task<IReadOnlyDictionary<int, AuthorDto>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            return (await _authorRepository.GetManyAuthorsByIds(keys)).ToDictionary(i=> i.Id);
        }
    }
}
