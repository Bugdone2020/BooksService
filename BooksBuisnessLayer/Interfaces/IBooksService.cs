using BooksBuisnessLayer.DTOs;
using BooksDataAccesLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksBuisnessLayer.Interfaces
{
    public interface IBooksService
    {
        Task<Guid> CreateBook(BookDTO bookDTO);
        Task<Book> DeleteBookById(Guid id);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(Guid id);
        Task<Book> UpdateBook(Guid id, BookDTO bookDTO);
    }
}
