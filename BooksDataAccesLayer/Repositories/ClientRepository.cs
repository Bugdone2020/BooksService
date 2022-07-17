using BooksDataAccesLayer.Interfaces;
using BooksDataAccesLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDataAccesLayer.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly EFCoreDbContext _dbContext;
        public ClientRepository(EFCoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> Create(User user)
        {
            user.Id = Guid.NewGuid();
            await _dbContext.Clients.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<User> DeleteById(Guid id)
        {
            User user = await GetById(id);
            if (user != null)
            {
                _dbContext.Clients.Remove(user);
                await _dbContext.SaveChangesAsync();
            }

            return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task<User> GetById(Guid id)
        {
            return await _dbContext.Clients.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> Update(User user)
        {
            _dbContext.Attach(user);
            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return user;
        }
    }
}
