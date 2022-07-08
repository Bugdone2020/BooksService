using Microsoft.EntityFrameworkCore;
using BooksDataAccesLayer.Models;

namespace BooksDataAccesLayer
{
    public class EFCoreDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
