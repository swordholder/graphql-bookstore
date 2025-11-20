using BookStore.API.Schemas.Subscriptions;
using HotChocolate.Subscriptions;

namespace BookStore.API.Schemas.Mutations
{
    public class Mutation
    {
        private readonly List<Book> _books;

        public Mutation()
        {
           _books = new List<Book>();
        }

        public async Task<Book> CreateBook(int id, string title, Genre genre, int publishedYear, decimal price, Author author, [Service]ITopicEventSender topicEventSender)
        {
            var book = new Book
            {
                Id = id,
                Title = title,
                Genre = genre,
                PublishedYear = publishedYear,                
                Price = price,
                Author = author
            };

            _books.Add(book);

            //Attribute based subscription
            await topicEventSender.SendAsync(nameof(Subscription.OnBookAdded), book);
            return book;
        }

        public async Task<Book> UpdateBook(int id, 
            string title, 
            Genre genre, 
            int publishedYear, 
            decimal price, 
            Author author, 
            [Service] ITopicEventSender topicEventSender)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                throw new Exception("Book not found");
            }

            book.Title = title;
            book.Genre = genre;
            book.PublishedYear = publishedYear;
            book.Price = price;
            book.Author = author;

            //Dynamic topic based subscription
            await topicEventSender.SendAsync(nameof(Subscription.OnBookUpdated), book);
            Console.WriteLine("📢 Publishing BookUpdated event");
            return book;
        }        

        public bool DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                throw new Exception("Book not found");
            }
            return _books.Remove(book);
        }
    }
}
