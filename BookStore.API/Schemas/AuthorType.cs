namespace BookStore.API.Schemas
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(b => b.Id);//.Type<NonNullType<IntType>>();
            descriptor.Field(b => b.Name);//.Type<NonNullType<StringType>>();
        }
    }
}
