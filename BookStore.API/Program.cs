using BookStore.API.Schemas.Mutations;
using BookStore.API.Schemas.Queries;

namespace BookStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register HotChocolate GraphQL server and the Query type
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>();

            var app = builder.Build();

            // Redirect root to the GraphQL endpoint UI and map GraphQL endpoint
            app.MapGet("/", () => Results.Redirect("/graphql", permanent: false));
            app.MapGraphQL();

            
            app.Run();
        }
    }
}