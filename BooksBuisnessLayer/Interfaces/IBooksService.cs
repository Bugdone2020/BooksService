using BooksBuisnessLayer.DTOs;
using BooksDataAccesLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksBuisnessLayer.Interfaces
{
    public interface IBooksService
    {
        Task<Guid> CreateBook(Book book);
        Task<bool> DeleteBookById(Guid id);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookById(Guid id);
        Task<BookDTO> GetBookFullInfo(Guid id);
        Task<bool> UpdateBook(Book book);
    }
}
