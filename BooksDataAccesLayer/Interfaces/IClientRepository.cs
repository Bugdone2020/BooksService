using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksDataAccesLayer.Models;

namespace BooksDataAccesLayer.Interfaces
{
    public interface IClientRepository
    {
        Task<Guid> Create(User client);
        Task<User> DeleteById(Guid id);
        Task<List<User>> GetAll();
        Task<User> GetById(Guid id);
        Task<User> Update(User client);
    }
}
