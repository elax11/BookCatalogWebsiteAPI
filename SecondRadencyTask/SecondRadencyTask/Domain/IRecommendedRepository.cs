using SecondRadencyTask.Controllers.Objects;
using SecondRadencyTask.Persistance.Models;

namespace SecondRadencyTask.Domain
{
    public interface IRecommendedRepository
    {
        public IEnumerable<BookViewModel> Get10BooksFilterByGenre(Func<Book, bool> orderExpression);
    }
}
