using System;
using System.Collections.Generic;
using BooksDataAccesLayer.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace BooksDataAccesLayer.Interfaces
{
    public interface IGenericRepository<T>
        where T : BaseEntity, new()
    {
        Task<Guid> Create(T item);
        Task<T> DeleteById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<T> GetByPredicate(Expression<Func<T, bool>> predicate);
        Task<T> Update(T item);
        
    }
}
