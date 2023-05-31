using Microsoft.AspNetCore.Mvc;
using SecondRadencyTask.Controllers.Models;
using SecondRadencyTask.Controllers.Objects;
using SecondRadencyTask.Domain;
using SecondRadencyTask.Persistance;
using SecondRadencyTask.Persistance.Models;
using System.Web.Http.Cors;

namespace SecondRadencyTask.Controllers
{
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly IBookRepository bookRepository;
        LibraryContext libraryContext { get; set; }

        public BooksController(IBookRepository bookRepository, LibraryContext libraryContext)
        {
            this.bookRepository = bookRepository;
            this.libraryContext = libraryContext;
        }

        [Route("api/[controller]")]
        [HttpGet]
        public ActionResult<IEnumerable<BookViewModel>> Get([FromQuery] GetAllBooksRequest request)
        {
            var orderExpresssion = GetOrderExpression(request);
            return Ok(bookRepository.GetBooks(orderExpresssion));
            /*var orderExpression = mapper.Map<OrderExpression>(request);
            var books = bookRepository.GetBooks(orderExpression);
            var booksViewModel = mapper.Map<BookViewModel>(books);
            return Ok(booksViewModel);*/
        }

        Func<Book, string> GetOrderExpression(GetAllBooksRequest request)
        {
            switch (request.Order)
            {
                case GetAllBooksOrder.Title:
                    return (Book book) => book.Title;
                default:
                    return (Book book) => book.Author;
            }
        }

        [Route("api/[controller]/{id}")]
        [HttpGet]
        public ActionResult<IEnumerable<BookViewModel>> Get(int id)
        {
            var orderExpresssion = GetOrderExpression(id);
            return Ok(bookRepository.GetBookById(orderExpresssion));
            /*var orderExpression = mapper.Map<OrderExpression>(request);
            var books = bookRepository.GetBooks(orderExpression);
            var booksViewModel = mapper.Map<BookViewModel>(books);
            return Ok(booksViewModel);*/
        }

        Func<Book, bool> GetOrderExpression(int id)
        {
            return (Book book) => book.Id == id;
        }

        [Route("api/[controller]/{id}")]
        [HttpDelete]
        public void Delete(int id, string secret)
        {
            var orderExpresssion = GetOrderExpressionForDeleting(id);
            bookRepository.DeleteBooksByIdWithKey(orderExpresssion, secret);
            /*var orderExpression = mapper.Map<OrderExpression>(request);
            var books = bookRepository.GetBooks(orderExpression);
            var booksViewModel = mapper.Map<BookViewModel>(books);
            return Ok(booksViewModel);*/
        }

        Func<Book, bool> GetOrderExpressionForDeleting(int id)
        {
            return (Book book) => book.Id == id;
        }

        [Route("api/[controller]/save")]
        [HttpPost]
        public ActionResult<BookCreatedResponse> Post(Book book)
        {
            if (book.Id != 0 && !libraryContext.Book.Any(x => x.Id == book.Id))
                return BadRequest("request is incorrect");
            return Ok(bookRepository.SaveBook(book));
            /*var orderExpresssion = GetOrderExpressionForSave(id);
            return bookRepository.SaveBook(orderExpresssion);*/
            /*var orderExpression = mapper.Map<OrderExpression>(request);
            var books = bookRepository.GetBooks(orderExpression);
            var booksViewModel = mapper.Map<BookViewModel>(books);
            return Ok(booksViewModel);*/
        }

        [Route("api/[controller]/{id}/review")]
        [HttpPut]
        public ActionResult<BookCreatedResponse> Put(int id, UpdateReviewRequest updateReviewRequest)
        {
            if (!libraryContext.Book.Any(x => x.Id == id))
                return BadRequest("request is incorrect");
            return Ok(bookRepository.SaveReview(id, updateReviewRequest));
        }

        [Route("api/[controller]/{id}/rate")]
        [HttpPut]
        public ActionResult<BookCreatedResponse> Put(int id, RateBook rateBook)
        {
            if (!libraryContext.Book.Any(x => x.Id == id))
                return BadRequest("request is incorrect");
            bookRepository.SaveRate(id, rateBook);
            return Ok();
        }
    }
}
