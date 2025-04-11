using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiAuthCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly ILogger<StoreController> _logger;

        public StoreController(ILogger<StoreController> logger)
        {
            _logger = logger;
        }

        // GET: api/<StoreController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return new Book[] {
                new Book
                {
                    Id = 1,
                    Title = "Test",
                    Author = "Author",
                    Price = 10.99m,
                    Quantity = 1,
                }
            };
        }

        // GET api/<StoreController>/5
        [HttpGet("{id}")]
        public Book Get(int id)
        {
          return new Book
            {
                Id = 1,
                Title = "Test",
                Author = "Author",
                Price = 10.99m,
                Quantity = 1,
            };
        }

        // POST api/<StoreController>
        [HttpPost]
        public void Post([FromBody] Book value)
        {
        }

        // PUT api/<StoreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
        }

        // DELETE api/<StoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; } = "Test";
        public string ISBN { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
