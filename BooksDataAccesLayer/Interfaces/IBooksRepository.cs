using System;
using System.Collections.Generic;
using BooksDataAccesLayer.Models;

namespace BooksDataAccesLayer.Interfaces
{
    public interface IBooksRepository
    {
        Guid Create(Book book);
        Book DeleteById(Guid id);
        IEnumerable<Book> GetAll();
        Book GetById(Guid id);
        Book Update(Book book);
    }
}
