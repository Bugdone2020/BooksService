using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using BooksDataAccesLayer.Models;
using BooksBuisnessLayer.Interfaces;
using BooksBuisnessLayer.DTOs;
using System.Threading.Tasks;

namespace BooksPresentationLayer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<Book> _logger;
        private readonly IBooksService _booksService;
        
        public BooksController(IBooksService booksService, ILogger<Book> logger, IMapper mapper)
        {
            _booksService = booksService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(Book book)
        {
            Guid guid = await _booksService.CreateBook(book);
            if (guid != Guid.Empty)
            {
                return Ok(guid);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, Book book)
        {
            book.Id = id;
            Book updatedBook = await _booksService.UpdateBook(book);
            
            if (updatedBook != null)
            {
                return Ok(updatedBook);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookById(Guid id)
        {
            Book book = await _booksService.DeleteBookById(id);
            if (book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }

        //[Authorize(Roles = Roles.Reader)]
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            IEnumerable<Book> books = await _booksService.GetAllBooks();
            
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            Book book = await _booksService.GetBookById(id);
            if (book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }

        [HttpGet("full/{id}")]
        public async Task<IActionResult> GetFullBookInfoById(Guid id)
        {
            //return await _booksService.GetBookFullInfo(id);
            BookDTO book = await _booksService.GetBookFullInfo(id);
            if (book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }
    }
}

