using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BooksDataAccesLayer.Models
{
    public class Book : BaseEntity
    {
        [Required]
        [MinLength(1)]
        [MaxLength(30)]
        public string Title { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(30)]
        public string Autor { get; set; }
        //public string Publisher { get; set; }
        //public int Age { get; set; }
        //public int Pages { get; set; }
        //public Genre Genre { get; set; }
    }
}
