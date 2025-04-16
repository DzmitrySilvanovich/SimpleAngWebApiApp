using Mapster;
using WebApiAuthCRUD.BAL.Contracts;
using WebApiAuthCRUD.BAL.Models;
using WebApiAuthCRUD.DAL.Contracts;
using WebApiAuthCRUD.DAL.Domains;

namespace WebApiAuthCRUD.BAL.Services
{
    public class BookService: IBookService
    {
        private readonly IRepository<Book> _repositoryBook;

        public BookService(IRepository<Book> repositoryBook)
        {
            _repositoryBook = repositoryBook; 
        }

        public Task<IEnumerable<BookReturnModel>> GetBooksAsync()
        {
           
            var books = _repositoryBook.GetAll();
            return Task.FromResult<IEnumerable<BookReturnModel>>(books.ProjectToType<BookReturnModel>().ToList());
        }

        public async Task<BookReturnModel> GetBookByIdAsync(int id)
        {
            var book = await _repositoryBook.GetByIdAsync(id);
            return book.Adapt<BookReturnModel>();
        }

        public async Task<Book> AddBookAync(Book book)
        {
          return  await _repositoryBook.CreateAsync(book);
        }

        public async Task UpdateBookAync(Book book)
        {
            await _repositoryBook.UpdateAsync(book);
        }

        public async Task DeleteBookAync(int id)
        {
            await _repositoryBook.DeleteAsync(id);
        }
    }
}
