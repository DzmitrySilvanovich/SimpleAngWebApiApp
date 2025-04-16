using Mapster;
using Microsoft.AspNetCore.Mvc;
using WebApiAuthCRUD.BAL.Contracts;
using WebApiAuthCRUD.BAL.Models;
using WebApiAuthCRUD.DAL.Domains;

namespace WebApiAuthCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController(ILogger<StoreController> logger, IBookService bookService) : ControllerBase
    {
        private readonly ILogger<StoreController> _logger = logger;
        private readonly IBookService _bookService = bookService;

        [HttpGet]
        public async Task<IEnumerable<BookReturnModel>> Get()
        {
              var books = await _bookService.GetBooksAsync();
             return books;
        }

        [HttpGet("{id}")]
        public async Task<BookReturnModel> Get(int id)
        {
          return  await _bookService.GetBookByIdAsync(id);
        }

        [HttpPost]
        public async Task Post([FromBody] BookViewModel bookViewModel)
        {
            await _bookService.AddBookAync(bookViewModel.Adapt<Book>());
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] BookViewModel bookViewModel)
        {
            await _bookService.UpdateBookAync(bookViewModel.Adapt<Book>());
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _bookService.DeleteBookAync(id);
        }
    }
}
