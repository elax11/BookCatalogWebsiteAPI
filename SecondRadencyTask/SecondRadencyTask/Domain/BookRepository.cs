using SecondRadencyTask.Controllers.Models;
using SecondRadencyTask.Controllers.Objects;
using SecondRadencyTask.Persistance;
using SecondRadencyTask.Persistance.Models;

namespace SecondRadencyTask.Domain
{
    public class BookRepository : IBookRepository
    {
        LibraryContext libraryContext { get; set; }
        ILibraryConfiguration configuration { get; set; }
        public BookRepository(LibraryContext libraryContext, ILibraryConfiguration configuration)
        {
            this.libraryContext = libraryContext;
            this.configuration = configuration;
        }
        public IEnumerable<BookViewModel> GetBooks(Func<Book, string> orderExpression)
        {
            var list = libraryContext.Book
                    .OrderBy(orderExpression)
                    .Select(x => new BookViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Author = x.Author,
                        Rating = GetRating(x),
                        ReviewsNumber = GetReviewsNumber(x)
                    })
                    .ToList();
            return list;
        }

        private int GetReviewsNumber(Book x)
        {
            return libraryContext.Review.Where(y => y.BookId == x.Id).DefaultIfEmpty().Count();
        }

        private decimal GetRating(Book x)
        {
            return (decimal)libraryContext.Rating.Where(y => y.BookId == x.Id).Select(y => y.Score).DefaultIfEmpty().Average();
        }

        public IEnumerable<BookViewModelById> GetBooksById(Func<Book, bool> order)
        {
            var list = libraryContext.Book
                    .Where(order)
                    .Select(x => new BookViewModelById
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Author = x.Author,
                        Cover = x.Cover,
                        Content = x.Content,
                        Rating = (decimal)libraryContext.Rating.Where(y => y.BookId == x.Id).Select(y => y.Score).Average(),
                        Reviews = libraryContext.Review
                            .Where(y => y.BookId == x.Id)
                    })
                    .ToList();
            return list;
        }
        public string DeleteBooksByIdWithKey(Func<Book, bool> order, string secret)
        {
            if (secret == configuration.SecretKey)
            {
                var temp = libraryContext.Book.Where(order).Single<Book>();
                libraryContext.Book.Remove(temp);
                libraryContext.SaveChanges();
                return "Record has successfully Deleted";
            }
            else return "Secret key in not valid!";
        }

        public BookCreatedResponse SaveBook(Book book)
        {
            if (libraryContext.Book.Any(x => x.Id == book.Id))
            {
                libraryContext.Book.Update(book);
                libraryContext.SaveChanges();
                return new BookCreatedResponse {Id = book.Id };
            }
            else
            {
                book.Id = libraryContext.Book.Max(x => x.Id) + 1;
                libraryContext.Book.Add(book);
                libraryContext.SaveChanges();
                return new BookCreatedResponse { Id = book.Id };
            }
        }

        public BookCreatedResponse SaveReview(int id, UpdateReviewRequest updateReviewRequest)
        {
            var newReview = new Review
            {
                Id = libraryContext.Review.Max(x => x.Id) + 1,
                Message = updateReviewRequest.Message,
                BookId = id,
                Reviewer = updateReviewRequest.Reviewer
            };
            libraryContext.Review.Add(newReview);
            libraryContext.SaveChanges();
            return new BookCreatedResponse { Id = id };
        }

        public void SaveRate(int id, RateBook rateBook)
        {
            var newRating = new Rating
            {
                Id = libraryContext.Rating.Max(x => x.Id) + 1,
                BookId = id,
                Score = rateBook.Score
            };
            libraryContext.Rating.Add(newRating);
            libraryContext.SaveChanges();
        }
    }
}
