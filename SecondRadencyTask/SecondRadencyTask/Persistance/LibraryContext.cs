using Microsoft.EntityFrameworkCore;
using SecondRadencyTask.Persistance.Models;

namespace SecondRadencyTask.Persistance
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "BooksDb");
        }*/
        public DbSet<Review> Review { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Rating> Rating { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rating>().HasData(
                new Rating
                {
                    Id = 1,
                    BookId = 1,
                    Score = 80
                },
                new Rating
                {
                    Id = 2,
                    BookId = 2,
                    Score = 89
                },
                new Rating
                {
                    Id = 3,
                    BookId = 3,
                    Score = 69
                },
                new Rating
                {
                    Id = 4,
                    BookId = 4,
                    Score = 36
                },
                new Rating
                {
                    Id = 5,
                    BookId = 5,
                    Score = 99
                },
                new Rating
                {
                    Id = 6,
                    BookId = 6,
                    Score = 95
                },
                new Rating
                {
                    Id = 7,
                    BookId = 7,
                    Score = 65
                },
                new Rating
                {
                    Id = 8,
                    BookId = 8,
                    Score = 78
                },
                new Rating
                {
                    Id = 9,
                    BookId = 9,
                    Score = 63
                },
                new Rating
                {
                    Id = 10,
                    BookId = 10,
                    Score = 45
                },
                new Rating
                {
                    Id = 11,
                    BookId = 3,
                    Score = 56
                },
                new Rating
                {
                    Id = 12,
                    BookId = 2,
                    Score = 78
                },
                new Rating
                {
                    Id = 13,
                    BookId = 6,
                    Score = 56
                },
                new Rating
                {
                    Id = 14,
                    BookId = 6,
                    Score = 78
                },
                new Rating
                {
                    Id = 15,
                    BookId = 9,
                    Score = 90
                },
                new Rating
                {
                    Id = 16,
                    BookId = 9,
                    Score = 78
                },
                new Rating
                {
                    Id = 17,
                    BookId = 3,
                    Score = 67
                },
                new Rating
                {
                    Id = 18,
                    BookId = 8,
                    Score = 92
                },
                new Rating
                {
                    Id = 19,
                    BookId = 6,
                    Score = 68
                },
                new Rating
                {
                    Id = 20,
                    BookId = 5,
                    Score = 45
                }
            );
            modelBuilder.Entity<Review>().HasData(
                    new Review
                    {
                        Id = 1,
                        Message = "dfsf",
                        BookId = 1,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 2,
                        Message = "dfgs",
                        BookId = 1,
                        Reviewer = "ewr"
                    },
                    new Review
                    {
                        Id = 3,
                        Message = "dfsf",
                        BookId = 2,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 4,
                        Message = "dfsf",
                        BookId = 2,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 5,
                        Message = "dfsf",
                        BookId = 3,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 6,
                        Message = "dfsf",
                        BookId = 3,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 7,
                        Message = "dfsf",
                        BookId = 4,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 8,
                        Message = "dfsf",
                        BookId = 4,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 9,
                        Message = "dfsf",
                        BookId = 5,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 10,
                        Message = "dfsf",
                        BookId = 5,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 11,
                        Message = "dfsf",
                        BookId = 6,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 12,
                        Message = "dfsf",
                        BookId = 6,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 13,
                        Message = "dfsf",
                        BookId = 7,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 14,
                        Message = "dfsf",
                        BookId = 7,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 15,
                        Message = "dfsf",
                        BookId = 8,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 16,
                        Message = "dfsf",
                        BookId = 8,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 17,
                        Message = "dfsf",
                        BookId = 1,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 18,
                        Message = "dfsf",
                        BookId = 9,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 19,
                        Message = "dfsf",
                        BookId = 9,
                        Reviewer = "sdad"
                    },
                    new Review
                    {
                        Id = 20,
                        Message = "dfsf",
                        BookId = 10,
                        Reviewer = "sdad"
                    }
                );
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Harry Potter and the Philosopher's Stone",
                    Cover = "Harry Potter and the Philosopher's Stone",
                    Content = "Harry Potter and the Philosopher's Stone",
                    Author = "J. K. Rowling",
                    Genre = "Horror"
                },
                new Book
                {
                    Id = 2,
                    Title = "Harry Potter and the Chamber of Secrets",
                    Cover = "Harry Potter and the Chamber of Secrets",
                    Content = "Harry Potter and the Chamber of Secrets",
                    Author = "J. K. Rowling",
                    Genre = "Fantasy"
                },
                new Book
                {
                    Id = 3,
                    Title = "Harry Potter and the Prisoner of Azkaban",
                    Cover = "Harry Potter and the Prisoner of Azkaban",
                    Content = "Harry Potter and the Prisoner of Azkaban",
                    Author = "J. K. Rowling",
                    Genre = "Fantasy"
                },
                new Book
                {
                    Id = 4,
                    Title = "The Hobbit",
                    Cover = "The Hobbit",
                    Content = "The Hobbit",
                    Author = "J. R. R. Tolkien",
                    Genre = "Fantasy"
                },
                new Book
                {
                    Id = 5,
                    Title = "The Lord of the Rings",
                    Cover = "The Lord of the Rings",
                    Content = "The Lord of the Rings",
                    Author = "J. R. R. Tolkien",
                    Genre = "Adventure"
                },
                new Book
                {
                    Id = 6,
                    Title = "The Adventures of Tom Bombadil",
                    Cover = "The Adventures of Tom Bombadil",
                    Content = "The Adventures of Tom Bombadil",
                    Author = "J. R. R. Tolkien",
                    Genre = "Poetry"
                },
                new Book
                {
                    Id = 7,
                    Title = "A Game of Thrones",
                    Cover = "A Game of Thrones",
                    Content = "A Game of Thrones",
                    Author = "George R. R. Martin",
                    Genre = "Horror"
                },
                new Book
                {
                    Id = 8,
                    Title = "A Clash of Kings",
                    Cover = "A Clash of Kings",
                    Content = "A Clash of Kings",
                    Author = "George R. R. Martin",
                    Genre = "Fantasy"
                },
                new Book
                {
                    Id = 9,
                    Title = "Rob Roy",
                    Cover = "Rob Roy",
                    Content = "Rob Roy",
                    Author = "Walter Scott",
                    Genre = "History"
                },
                new Book
                {
                    Id = 10,
                    Title = "The Heart of Mid-Lothian",
                    Cover = "The Heart of Mid-Lothian",
                    Content = "The Heart of Mid-Lothian",
                    Author = "Walter Scott",
                    Genre = "History"
                }
            );
        }
    }
}
