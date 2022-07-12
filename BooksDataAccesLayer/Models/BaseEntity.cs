using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDataAccesLayer.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
