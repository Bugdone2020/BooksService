using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksBuisnessLayer.DTOs
{
    public class BookDTO
    {
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public IEnumerable<BookRevisionDto> BookRevisions { get; set; }
    }
}
