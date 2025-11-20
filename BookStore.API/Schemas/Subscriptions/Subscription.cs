using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace BookStore.API.Schemas.Subscriptions
{
    public class Subscription
    {
        //Attribute based subscription
        [Subscribe]
        public Book OnBookAdded([EventMessage]Book book)
        {
            return book; 
        }

        //Dynamic topic name based subscription
        [Subscribe(MessageType = typeof(Book))]
        public async ValueTask<ISourceStream<Book>> OnBookUpdated(
        [Service] ITopicEventReceiver receiver,
        CancellationToken cancellationToken)
        {
            var sourceStream =  await receiver.SubscribeAsync<Book>(nameof(OnBookUpdated), cancellationToken);

            Console.WriteLine($"📚 Subscription triggered: {sourceStream}");

            return sourceStream;
        }
    }
}
