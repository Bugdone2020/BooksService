using BooksDataAccesLayer.Interfaces;
using BooksDataAccesLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksDataAccesLayer.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly EFCoreDbContext _dbContext;
        public BooksRepository(EFCoreDbContext dbContext)
        { 
            _dbContext = dbContext;
        }
        public Guid Create(Book book)
        {
            book.Id = Guid.NewGuid();
            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();

            return book.Id;
        }

        public Book DeleteById(Guid id)
        {
            Book entity = GetById(id);
            if (entity != null)
            {
                _dbContext.Books.Remove(entity);
                _dbContext.SaveChanges();
            }

            return entity;
        }

        public IEnumerable<Book> GetAll()
        {
            return _dbContext.Books.ToList();
        }

        public Book GetById(Guid id)
        {
            return _dbContext.Books.Where(x => x.Id == id).FirstOrDefault();
        }

        public Book Update(Book book)
        {
            _dbContext.Attach(book);
            _dbContext.Entry(book).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return book;
        }
    }
}
