using BooksDataAccesLayer.Interfaces;
using BooksDataAccesLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksDataAccesLayer.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly EFCoreDbContext _dbContext;
        public BooksRepository(EFCoreDbContext dbContext)
        { 
            _dbContext = dbContext;
        }
        public async Task<(Book book, IEnumerable<BookRevision> bookRevisions)> GetFullInfo(Guid id)
        {
            var result = await _dbContext.BookRevisions.Include(x => x.Book).Where(x => x.BookId == id).ToListAsync();

            var book = result.FirstOrDefault()?.Book;

            return (book, result);
        }

        #region OldIBooksRepository
        //public async Task<Guid> Create(Book book)
        //{
        //    book.Id = Guid.NewGuid();
        //    await _dbContext.Books.AddAsync(book);
        //    await _dbContext.SaveChangesAsync();

        //    return book.Id;
        //}

        //public async Task<Book> DeleteById(Guid id)
        //{
        //    Book book = await GetById(id);
        //    if (book != null)
        //    {
        //        _dbContext.Books.Remove(book);
        //        await _dbContext.SaveChangesAsync();
        //    }

        //    return book;
        //}

        //public async Task<List<Book>> GetAll()
        //{
        //    return await _dbContext.Books.ToListAsync();
        //}

        //public async  Task<Book> GetById(Guid id)
        //{
        //    return await _dbContext.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
        //}

        //public async Task<Book> Update(Book book)
        //{
        //    _dbContext.Attach(book);
        //    _dbContext.Entry(book).State = EntityState.Modified;
        //    await _dbContext.SaveChangesAsync();

        //    return book;
        //}
        #endregion
    }
}
