using System.Linq.Expressions;

namespace WebApiAuthCRUD.DAL.Contracts
{
    public interface IRepository<T> where T : class
    {
        public Task<T> CreateAsync(T entity);
        public Task CreateAsync(IEnumerable<T> entities);

        public IQueryable<T> GetAll();

        public ValueTask<T?> GetByIdAsync(object id);

        public Task UpdateAsync(T entity);

        public Task DeleteAsync(object id);

        public Task DeleteAsync(T entity);
        public Task DeleteAsync(Expression<Func<T, bool>> predicate);

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
