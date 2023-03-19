using SecondRadencyTask.Controllers.Objects;
using SecondRadencyTask.Persistance.Models;

namespace SecondRadencyTask.Domain
{
    public interface IBookRepository
    {
        public IEnumerable<BookViewModel> GetBooks(Func<Book, string> order);
        public IEnumerable<BookViewModelById> GetBooksById(Func<Book, bool> order);
        public string DeleteBooksByIdWithKey(Func<Book, bool> order, string secret);
        public BookCreatedResponse SaveBook(Book book);
        public BookCreatedResponse SaveReview(int id, UpdateReviewRequest updateReviewRequest);
        public void SaveRate(int id, RateBook rateBook);
    }
}
