using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksDataAccesLayer.Models;

namespace BooksDataAccesLayer.Interfaces
{
    public interface IBooksRepository
    {
        Task<(Book book, IEnumerable<BookRevision> bookRevisions)> GetFullInfo(Guid id);
    }
}
