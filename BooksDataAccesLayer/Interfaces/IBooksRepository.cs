using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksDataAccesLayer.Models;

namespace BooksDataAccesLayer.Interfaces
{
    public interface IBooksRepository
    {
        Task<(Book book, IEnumerable<BookRevision> bookRevisions)> GetFullInfo(Guid id);
        //Task<Guid> Create(Book book);
        //Task<Book> DeleteById(Guid id);
        //Task<List<Book>> GetAll();
        //Task<Book> GetById(Guid id);
        //Task<Book> Update(Book book);
    }
}
