using SecondRadencyTask.Controllers.Models;
using SecondRadencyTask.Controllers.Objects;
using SecondRadencyTask.Persistance.Models;

namespace SecondRadencyTask.Domain
{
    public interface IBookRepository
    {
        public IEnumerable<BookViewModel> GetBooks(Func<Book, string> order);
    }
}
