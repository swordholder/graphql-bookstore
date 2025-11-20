namespace BookStore.API.Schemas
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Field(b => b.Id);//.Type<NonNullType<IntType>>();
            descriptor.Field(b => b.Title);//.Type<NonNullType<StringType>>();
            descriptor.Field(b => b.Price);//.Type<NonNullType<DecimalType>>();
            descriptor.Field(b => b.Genre);//.Type<NonNullType<EnumType>>();
            descriptor.Field(b => b.PublishedYear);//.Type<NonNullType<IntType>>();
            descriptor.Field(b => b.Author);//.Type<NonNullType<AuthorType>>();
        }
    }     
}
