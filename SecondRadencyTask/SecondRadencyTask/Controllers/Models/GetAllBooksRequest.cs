using Microsoft.AspNetCore.Mvc;

namespace SecondRadencyTask.Controllers.Models
{
    public class GetAllBooksRequest
    {
        public GetAllBooksOrder Order { get; set; } = GetAllBooksOrder.Author;
    }
}
