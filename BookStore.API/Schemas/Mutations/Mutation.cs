using BookStore.API.DTOs;
using BookStore.API.Mappers;
using BookStore.API.Models;
using BookStore.API.Repositories;
using BookStore.API.Schemas.Subscriptions;
using HotChocolate.Subscriptions;

namespace BookStore.API.Schemas.Mutations
{
    public class Mutation
    {
        private readonly BookRepository _booksRepo;
        private readonly BookMapper _bookMapper;
        private readonly AuthorRepository _authorRepository;

        public Mutation(BookRepository bookRepository, BookMapper bookMapper, AuthorRepository authorRepository)
        {
            _booksRepo = bookRepository;
            _bookMapper = bookMapper;
            _authorRepository = authorRepository;
        }

        public async Task<Book> CreateBook(int id, string title, Genre genre, int publishedYear, decimal price, Author author, [Service]ITopicEventSender topicEventSender)
        {
            var book = new Book(_authorRepository)
            {
                Id = id,
                Title = title,
                Genre = genre,
                PublishedYear = publishedYear,                
                Price = price,
                Author = author
            };

            var bookDto = await _bookMapper.ToDto(book);

            await _booksRepo.AddBookAsync(bookDto);

            //Attribute based subscription
            await topicEventSender.SendAsync(nameof(Subscription.OnBookAdded), book);
            return book;
        }

        public async Task<BookDto> UpdateBook(int id, 
            string title, 
            Genre genre, 
            int publishedYear, 
            decimal price, 
            Author author, 
            [Service] ITopicEventSender topicEventSender)
        {
            var book = await _booksRepo.GetBookByIdAsync(id);

            if (book == null)
            {
                throw new Exception("Book not found");
            }

            book.Title = title;
            book.Genre = genre;
            book.PublishedYear = publishedYear;
            book.Price = price;

            if (author != null)
            { 
                book.Author = _bookMapper.ToDtoAuthor(author); 
            }

            await _booksRepo.UpdateBookAsync(book);

            //Dynamic topic based subscription
            await topicEventSender.SendAsync(nameof(Subscription.OnBookUpdated), book);
            Console.WriteLine("📢 Publishing BookUpdated event");
            return book;
        }        

        public async Task<bool> DeleteBook(int id)
        {
            var book = await _booksRepo.GetBookByIdAsync(id);

            if (book == null)
            {
                return false;
            }           

            return await _booksRepo.DeleteBookAsync(book.Id);
        }
    }
}
