using AutoMapper;
using BooksService.DTOs;
using BooksService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        static List<Book> Books;
        private IMapper _mapper;
        private readonly ILogger<Book> _logger;
        static BooksController()
        {
            Books = new List<Book>();
            Books.Add(new Book
            {
                Id = Guid.NewGuid(),
                Name = "CLR via C#",
                Autor = "Jeffrey Richter",
                Publisher = " Microsoft Press",
                Age = 2012,
                Pages = 896,
                Genre = Genre.Science
            });
        }
        public BooksController(ILogger<Book> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(BookDTO bookDTO)
        {
            Book book = _mapper.Map<Book>(bookDTO);
            book.Id = Guid.NewGuid();
            if (book.Id != Guid.Empty)
            {
                Books.Add(book);
                return Ok(book.Id);
            }
            return BadRequest();

        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, BookDTO bookDTO)
        {
            Book updatedBook = _mapper.Map<Book>(bookDTO);
            updatedBook.Id = id;
            Book book = Books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                var index = Books.IndexOf(book);
                Books[index] = updatedBook;
                return Ok(updatedBook);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id)
        {
            Book book = Books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                Books.Remove(book);
                return Ok(book);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(Books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Book book = Books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                return Ok(book);
            }
            return NotFound();
        }
    }
}

