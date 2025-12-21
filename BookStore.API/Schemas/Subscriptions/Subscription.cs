using BookStore.API.Models;
using HotChocolate.Subscriptions;
using System.Runtime.CompilerServices;

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

        [Subscribe(MessageType = typeof(Book))]
        public async IAsyncEnumerable<Book> OnBookUpdated(
            [Service] ITopicEventReceiver receiver,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var sourceStream = await receiver.SubscribeAsync<Book>(nameof(OnBookUpdated), cancellationToken);

            if (sourceStream is null)
            {
                yield break;
            }

            await foreach (var book in sourceStream.ReadEventsAsync().WithCancellation(cancellationToken))
            {
                yield return book;
            }
        }
    }
}
