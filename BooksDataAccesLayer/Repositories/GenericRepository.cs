using System;
using BooksDataAccesLayer.Interfaces;
using BooksDataAccesLayer.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BooksDataAccesLayer.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : BaseEntity, new()
    {
        private readonly EFCoreDbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(EFCoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<Guid> Create(T item)
        {
            item.Id = Guid.NewGuid();
            await _dbSet.AddAsync(item);
            await _dbContext.SaveChangesAsync();

            return item.Id;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            var item = new T { Id = id};
            _dbContext.Entry(item).State = EntityState.Detached;
            
            return await _dbContext.SaveChangesAsync() != 0;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T> GetByPredicate(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(T item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;

            return await _dbContext.SaveChangesAsync() != 0;
        }
    }
}
