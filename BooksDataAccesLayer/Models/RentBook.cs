﻿using System;
using BooksDataAccesLayer.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDataAccesLayer.Models
{
    public class RentBook : BaseEntity
    {
        [ForeignKey("Client")]
        public Guid ClientId { get; set; }
        [ForeignKey("LibraryBook")]
        public Guid LibraryBookId { get; set; }
        public LibraryBook LibraryBook { get; set; }
        public User Client { get; set; }
        public DateTime DateGet { get; set; }
        public DateTime? DateReturn { get; set; }
    }
}
