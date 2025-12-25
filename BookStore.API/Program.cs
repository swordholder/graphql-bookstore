using BookStore.API.Mappers;
using BookStore.API.Models;
using BookStore.API.Repositories;
using BookStore.API.Schemas.Mutations;
using BookStore.API.Schemas.Queries;
using BookStore.API.Schemas.Subscriptions;
using BookStore.API.Services;
using Microsoft.EntityFrameworkCore;

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
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddType<AuthorType>()
                .AddType<BookType>()
                .AddInMemorySubscriptions();
            builder.Logging.AddConsole();

            // Register EF DbContext with a pooled factory for better performance
            builder.Services.AddPooledDbContextFactory<BookStoreDbContext>(options =>
            {
                options.UseSqlite(builder.Configuration.GetConnectionString("BookStoreDb"));
            });

            builder.Services.AddScoped<BookRepository>();

            var app = builder.Build();

            // Automatically apply EF migrations on startup
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var logger = services.GetRequiredService<ILogger<Program>>();
                try
                {
                    var factory = services.GetRequiredService<IDbContextFactory<BookStoreDbContext>>();
                    using var db = factory.CreateDbContext();
                    db.Database.Migrate();
                    logger.LogInformation("Database migrations applied successfully.");
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while applying database migrations.");
                    throw;
                }
            }                  

            app.UseRouting();
            app.UseWebSockets();

            // Redirect root to the GraphQL endpoint UI and map GraphQL endpoint
            app.MapGet("/", () => Results.Redirect("/graphql", permanent: false));
            app.MapGraphQL();

            app.Run();
        }
    }
}