using System.Linq.Expressions;
using TravelaFinalApp.Domain.Entities;

namespace TravelaFinalApp.Persistence.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetEntityAsync(Expression<Func<T,bool>> predicate=null,params string[] includes);
        Task<List<T>> GetAllAsync(Expression<Func<T,bool>> predicate=null,params string[] includes);
        Task<bool> IsExist(Expression<Func<T, bool>> predicate = null);
        Task<T> GetByIdAsync(int id);
        Task<int> SaveChangesAsync();
        IQueryable<T> GetAllIncludes(params string[] includes);
    }
}
