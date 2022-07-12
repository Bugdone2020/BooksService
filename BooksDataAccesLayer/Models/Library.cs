using System;
using BooksDataAccesLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksDataAccesLayer.Models
{
    public class Library : BaseEntity
    {
        [ForeignKey("Point")]
        public Guid LocationId { get; set; }
        [ForeignKey("City")]
        public Guid CityId { get; set; }
        public City City { get; set; }
        public Point Location { get; set; }
        public string FullAddress { get; set; }
    }
}
