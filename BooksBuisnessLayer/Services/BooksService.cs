using BooksBuisnessLayer.DTOs;
using BooksBuisnessLayer.Interfaces;
using BooksDataAccesLayer.Models;
using System;
using System.Collections.Generic;
using BooksDataAccesLayer.Interfaces;
using AutoMapper;
using System.Threading.Tasks;

namespace BooksBuisnessLayer.Services
{
    public class BooksService : IBooksService
    {
        public readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BooksService(IBooksRepository booksRepository, IMapper mapper)
        {
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateBook(BookDTO bookDTO)
        {
            Book book = _mapper.Map<Book>(bookDTO);
            ValidateBookState(book);
            return await _booksRepository.Create(book);
        }

        public async Task<Book> DeleteBookById(Guid id)
        {
            return await _booksRepository.DeleteById(id);
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _booksRepository.GetAll();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _booksRepository.GetById(id);
        }

        public async Task<Book> UpdateBook(Guid id, BookDTO bookDTO)
        {
            Book book = _mapper.Map<Book>(bookDTO);
            if (book != null)
            {
                ValidateBookState(book);
                book.Id = id;
                return await _booksRepository.Update(book);
            }

            return null;
        }

        private static void ValidateBookState(Book book)
        {
            if (book.Pages < 10 || book.Pages > 2_000)
            {
                throw new ArgumentException("Invalid pages count!");
            }
        }
    }
}
