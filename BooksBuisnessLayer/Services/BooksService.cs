using BooksBuisnessLayer.DTOs;
using BooksBuisnessLayer.Interfaces;
using BooksDataAccesLayer.Models;
using System;
using System.Collections.Generic;
using BooksDataAccesLayer.Interfaces;
using AutoMapper;

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

        Guid IBooksService.CreateBook(BookDTO bookDTO)
        {
            Book book = _mapper.Map<Book>(bookDTO);

            return _booksRepository.Create(book);
        }

        Book IBooksService.DeleteBookById(Guid id)
        {
            return _booksRepository.DeleteById(id);
        }

        IEnumerable<Book> IBooksService.GetAllBooks()
        {
            return _booksRepository.GetAll();
        }

        Book IBooksService.GetBookById(Guid id)
        {
            return _booksRepository.GetById(id);
        }

        Book IBooksService.UpdateBook(Guid id, BookDTO bookDTO)
        {
            Book book = _mapper.Map<Book>(bookDTO);
            if (book != null)
            {
                book.Id = id;
                return _booksRepository.Update(book);
            }

            return null;
        }
    }
}
