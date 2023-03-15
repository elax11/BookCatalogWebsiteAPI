using SecondRadencyTask.Controllers.Models;
using SecondRadencyTask.Controllers.Objects;
using SecondRadencyTask.Persistance;
using SecondRadencyTask.Persistance.Models;

namespace SecondRadencyTask.Domain
{
    public class BookRepository : IBookRepository
    {
        LibraryContext libraryContext { get; set; }
        public BookRepository(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
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
                        Rating = (decimal)libraryContext.Rating.Where(y => y.BookId == x.Id).Select(y => y.Score).Average(),
                        ReviewsNumber = libraryContext.Review.Where(y => y.BookId == x.Id).Count()
                    })
                    .ToList();
            return list;
        }
    }
}
