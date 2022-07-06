using BooksBuisnessLayer.DTOs;
using BooksDataAccesLayer.Models;
using System;
using System.Collections.Generic;

namespace BooksBuisnessLayer.Interfaces
{
    public interface IBooksService
    {
        Guid CreateBook(BookDTO bookDTO);
        Book DeleteBookById(Guid id);
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(Guid id);
        Book UpdateBook(Guid id, BookDTO bookDTO);
    }
}
