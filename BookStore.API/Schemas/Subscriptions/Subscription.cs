namespace BookStore.API.Schemas.Subscriptions
{
    public class Subscription
    {
        [Subscribe]
        public Book OnBookAdded([EventMessage]Book book)
        {
            return book; 
        }
    }
}
