using BookShelfApi.Data;
using BookShelfApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShelfApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;

        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return BookTools.GetBooks();
        }

        [HttpPost("/add/{bookName}")]
        public void Add(string bookName)
        {
            BookTools.AddBook(bookName);
        }
    }
}
