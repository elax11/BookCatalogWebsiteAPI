using Microsoft.AspNetCore.Mvc;
using SecondRadencyTask.Controllers.Objects;
using SecondRadencyTask.Domain;
using SecondRadencyTask.Persistance.Models;

namespace SecondRadencyTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecommendedController : ControllerBase
    {
        readonly IRecommendedRepository recommendedRepository;

        public RecommendedController(IRecommendedRepository recommendedRepository)
        {
            this.recommendedRepository = recommendedRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookViewModel>> Get(string genre)
        {
            var orderExpresssion = GetOrderExpression(genre);
            return Ok(recommendedRepository.Get10BooksFilterByGenre(orderExpresssion));
            /*var orderExpression = mapper.Map<OrderExpression>(request);
            var books = bookRepository.GetBooks(orderExpression);
            var booksViewModel = mapper.Map<BookViewModel>(books);
            return Ok(booksViewModel);*/
        }

        Func<Book, bool> GetOrderExpression(string genre)
        {
            return (Book book) => book.Genre == genre;
        }
    }
}
