using Microsoft.EntityFrameworkCore;

namespace BackExeBooks1.Models
{
    public class booksContext: DbContext
    {
        public booksContext(DbContextOptions<booksContext> options) : base(options)
        {

        }
        public DbSet<Book> Books => Set<Book>();
        public DbSet<PurchaseList> PurchaseLists => Set<PurchaseList>();
        public DbSet<User> Users { get; set; }
        public DbSet<PublishingHouse> PublishingHouses => Set<PublishingHouse>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<AuthorBook> AuthorBooks => Set<AuthorBook>();
        public DbSet<PurchaseListA> PurchaseListAs => Set<PurchaseListA>();
    }
}
