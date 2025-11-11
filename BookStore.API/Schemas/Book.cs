namespace BookStore.API.Schemas
{
    public enum Genre
    {
        Fiction = 0,
        NonFiction = 1,
        ScienceFiction = 2,
        Fantasy = 3,
        Mystery = 4,
        Biography = 5
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public int PublishedYear { get; set; }

        public decimal Price { get; set; }
    }
}
