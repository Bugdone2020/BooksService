using System;
using BooksDataAccesLayer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksBuisnessLayer.Interfaces
{
    public interface IClientService
    {
        bool RentABook(Book book, User user);
        bool ReturnABook(Book book, User user);
    }
}
