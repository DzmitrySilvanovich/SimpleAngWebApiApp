using System;
using System.Collections.Generic;
using WebApiAuthCRUD.BAL.Models;
using WebApiAuthCRUD.DAL.Domains;

namespace WebApiAuthCRUD.BAL.Contracts
{
    public interface IBookService
    {
        public Task<IEnumerable<BookReturnModel>> GetBooksAsync();
        public Task<BookReturnModel> GetBookByIdAsync(int id);
        public Task<Book> AddBookAync(Book book);
        public Task UpdateBookAync(Book book);
        public Task DeleteBookAync(int id);
    }
}
