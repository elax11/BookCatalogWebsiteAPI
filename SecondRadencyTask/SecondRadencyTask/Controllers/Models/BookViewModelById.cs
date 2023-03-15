using SecondRadencyTask.Persistance.Models;

namespace SecondRadencyTask.Controllers.Objects
{
    public class BookViewModelById
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Content { get; set; }
        public decimal Rating { get; set; }
        public IEnumerable<Review> Reviews { get; set; }
    }
}
