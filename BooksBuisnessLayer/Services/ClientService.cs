﻿using System;
using BooksBuisnessLayer.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksDataAccesLayer.Models;

namespace BooksBuisnessLayer.Services
{
    public class ClientService : IClientService
    {
        public bool RentABook(Book book, User user)
        {
            throw new NotImplementedException();
        }

        public bool ReturnABook(Book book, User user)
        {
            throw new NotImplementedException();
        }
    }
}
