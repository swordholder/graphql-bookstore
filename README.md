# GraphQL BookStore (BookStore.API)

Lightweight GraphQL API for managing books and authors built with .NET 9 and C# 13.

## Features
- GraphQL schema with Queries, Mutations, and Subscriptions
- In-memory data model for Books and Authors (easy to replace with EF Core or another DB)
- Example types: `Book`, `Author`, and `Genre` enum
- Ready to run via `dotnet` CLI or Visual Studio 2022

## Prerequisites
- .NET 9 SDK
- Visual Studio 2022 (updated) or any editor that supports .NET 9
- Git

## Get started (CLI)
1. Clone the repository
2. Navigate to the project directory
3. Run the application using:
   ```bash
   dotnet run
   ```
4. Open your browser and go to `http://localhost:5197/graphql` to access the GraphQL Playground.


## Query samples

### Fetch all books with their authors
```graphql
query
{
  books{
    id,
    title,
    price,
    genre,
    publishedYear,
    author{
      id,
      name,
      bio
    }
  }
}
```

### Fetch a book by id
```graphql
query
{
  book(id: 1){
    id,
    title,
    price,
    genre,
    publishedYear,
    author{
      id,
      name,
      bio
    }
  }
}
```

### Create a new book with author

```graphql
mutation{
  createBook(id: 1,title: "A good book",author:  {
     id: 1,
     name: "John Neuman",
     bio: "Not too bad author"
  },
  genre: NON_FICTION,
  price: 9.89,
  publishedYear: 2016
  )
{
    id,
    price,
    title,
    genre,
    publishedYear,
    author{
      id,
      name,
      bio
    }
  }  
}
```

### Update a book
```graphql
mutation
{
  updateBook(
    id: 1,
    price: 9.99,
    author:  {
       id: 2,
       name: "Neu Johnman",
       bio: "Bad actor"
    },
    genre: FICTION,
    publishedYear: 2009,
    title: "A bad book"
  )
  {
    id,
    title,
    price,
    genre,
    publishedYear,
    author{
      id,
      name,
      bio
    }
  }
}
```

### Delete a book
```graphql  
mutation {
  deleteBook(id: 1)
}
```

### Subscribe to new book additions
```graphql  
subscription
{
  onBookAdded{
    id,
    title,
    price,
    genre,
    publishedYear,
    author{
      id,
      name,
      bio
    }
  }
}
```

### Subsribe to book update
```graphql
subscription onBookUpdated() {
  onBookUpdated() {
    id
    title
    publishedYear
    price
    genre
    author {
      id
      name
    }
  }
}
```
