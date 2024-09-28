using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TravelaFinalApp.Domain.Entities;
using TravelaFinalApp.Persistence.Data;
using TravelaFinalApp.Persistence.Repositories.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TravelaFinalApp.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly TravelaDbContext _context;
        private DbSet<T> _table;
        public BaseRepository(TravelaDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task CreateAsync(T entity)
        {
            var result=_context.Entry(entity);
            result.State = EntityState.Added;
        }

        public async Task DeleteAsync(T entity)
        {
            var result=_context.Entry(entity);
            result.State = EntityState.Deleted;
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params string[] includes)
        {
            IQueryable<T> query = _table;
            if (includes.Length > 0)
            {
                query = GetAllIncludes(includes);
            }
            return predicate == null ? await query.ToListAsync() : await query.Where(predicate).ToListAsync();
        }

        

        public async Task<T> GetEntityAsync(Expression<Func<T, bool>> predicate = null, params string[] includes)
        {
            IQueryable<T> query = _table;
            if (includes.Length>0)
            {
                query=GetAllIncludes(includes);
            }
            return predicate==null? await query.FirstOrDefaultAsync():await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> IsExist(Expression<Func<T, bool>> predicate = null)
        {
           return predicate==null ? false : await _table.AnyAsync(predicate);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var result=_context.Entry(entity);
            result.State = EntityState.Modified;
        }
        public IQueryable<T> GetAllIncludes(params string[] includes)
        {
            IQueryable<T> query = _table;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return query;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.AsNoTracking().FirstOrDefaultAsync(x =>!x.IsDeleted && x.Id == id);
        }
    }
}
