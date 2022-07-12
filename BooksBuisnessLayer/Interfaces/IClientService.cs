using System;
using BooksDataAccesLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksBuisnessLayer.Interfaces
{
    internal interface IClientService
    {
        bool RentABook(Book book, Client client);
        bool ReturnABook(Book book, Client client);
    }
}
