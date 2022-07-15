using BooksBuisnessLayer.DTOs;
using BooksBuisnessLayer.Interfaces;
using BooksDataAccesLayer.Models;
using System;
using System.Collections.Generic;
using BooksDataAccesLayer.Interfaces;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;

namespace BooksBuisnessLayer.Services
{
    public class BooksService : IBooksService
    {
        private readonly IGenericRepository<Book> _genericBooksRepository;
        public readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BooksService(IGenericRepository<Book> genericBooksRepository,
            IBooksRepository booksRepository, 
            IMapper mapper)
        {
            _genericBooksRepository = genericBooksRepository;
            _booksRepository = booksRepository;
            _mapper = mapper;
        }

        public async Task<Guid> CreateBook(Book book)
        {
            return await _genericBooksRepository.Create(book);
        }

        public async Task<bool> DeleteBookById(Guid id)
        {
            return await _genericBooksRepository.DeleteById(id);
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _genericBooksRepository.GetAll();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _genericBooksRepository.GetById(id);
        }

        public async Task<bool> UpdateBook(Book book)
        {
            return await _genericBooksRepository.Update(book);
        }

        public async Task<BookDTO> GetBookFullInfo(Guid id)
        {
            var result = await _booksRepository.GetFullInfo(id);

            return MapTupleToBookDto(result);
        }

        private BookDTO MapTupleToBookDto((Book book, IEnumerable<BookRevision> bookRevisions) result)
        {
            return new BookDTO
            {
                Author = result.book?.Author,
                BookId = result.book.Id,
                Title = result.book.Title,
                BookRevisions = MapRevisions(result.bookRevisions)
            };
        }

        private IEnumerable<BookRevisionDto> MapRevisions(IEnumerable<BookRevision> bookRevisions)
        {
            return bookRevisions.Select(x => new BookRevisionDto
            {
                Price = x.Price,
                PagesCount = x.PagesCount,
                YearOfPublishing = x.YearOfPublishing
            });
        }
    }
}
