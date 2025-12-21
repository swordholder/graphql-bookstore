namespace BookStore.API.Models
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Field(b => b.Id);
            descriptor.Field(b => b.Title);
            descriptor.Field(b => b.Price);
            descriptor.Field(b => b.Genre);
            descriptor.Field(b => b.PublishedYear);
            descriptor.Field(b => b.Author);
        }
    }     
}
