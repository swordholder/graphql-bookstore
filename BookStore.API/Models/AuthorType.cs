namespace BookStore.API.Models
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(b => b.Id);
            descriptor.Field(b => b.Name);
        }
    }
}
