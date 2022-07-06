using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using BooksDataAccesLayer.Models;
using BooksBuisnessLayer.Interfaces;
using BooksBuisnessLayer.DTOs;

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
        public IActionResult CreateBook(BookDTO bookDTO)
        {
            Guid guid = _booksService.CreateBook(bookDTO);
            if (guid != Guid.Empty)
            {
                return Ok(guid);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(Guid id, BookDTO bookDTO)
        {
            Book updatedBook = _booksService.UpdateBook(id, bookDTO);
            
            if (updatedBook != null)
            {
                return Ok(updatedBook);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBookById(Guid id)
        {
            Book book = _booksService.DeleteBookById(id);
            if (book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            IEnumerable<Book> books = _booksService.GetAllBooks();
            
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(Guid id)
        {
            Book book = _booksService.GetBookById(id);
            if (book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }
    }
}

