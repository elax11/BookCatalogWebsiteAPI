using SecondRadencyTask.Controllers.Objects;
using SecondRadencyTask.Persistance;
using SecondRadencyTask.Persistance.Models;

namespace SecondRadencyTask.Domain
{
    public class RecommendedRepository : IRecommendedRepository
    {
        LibraryContext libraryContext { get; set; }
        public RecommendedRepository(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
        }
        public IEnumerable<BookViewModel> Get10BooksFilterByGenre(Func<Book, bool> orderExpression)
        {
            var list = libraryContext.Book
                    .Where(orderExpression)
                    .Select(x => new BookViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Author = x.Author,
                        Rating = (decimal)libraryContext.Rating.Where(y => y.BookId == x.Id).Select(y => y.Score).Average(),
                        ReviewsNumber = libraryContext.Review.Where(y => y.BookId == x.Id).Count()
                    })
                    .OrderBy(x => x.Rating)
                    .Where(x => x.ReviewsNumber >= 1)
                    .Take(10)
                    .ToList();
            return list;
        }
    }
}
