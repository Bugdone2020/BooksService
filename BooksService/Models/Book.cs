using System;

namespace BooksService.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Autor { get; set; }
        public string Publisher { get; set; }
        public int Age { get; set; }
        public int Pages { get; set; }
        public Genre Genre { get; set; }
    }
}
