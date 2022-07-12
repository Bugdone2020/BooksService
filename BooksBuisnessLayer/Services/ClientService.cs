using System;
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
        public bool RentABook(Book book, Client client)
        {
            throw new NotImplementedException();
        }

        public bool ReturnABook(Book book, Client client)
        {
            throw new NotImplementedException();
        }
    }
}
