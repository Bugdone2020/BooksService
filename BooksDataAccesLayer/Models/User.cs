using System;
using BooksDataAccesLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksDataAccesLayer.Models
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [ForeignKey("Role")]
        public Guid? RoleId { get; set; }
        public Role Role { get; set; }
    }
}
