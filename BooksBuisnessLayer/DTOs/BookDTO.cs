using System.ComponentModel.DataAnnotations;

namespace BooksBuisnessLayer.DTOs
{
    public class BookDTO
    {
        public string Name { get; set; }
        public string Autor { get; set; }
        public string Publisher { get; set; }
        [Required]
        public int Age { get; set; }
        public int Pages { get; set; }
        public string Genre { get; set; }
    }
}
