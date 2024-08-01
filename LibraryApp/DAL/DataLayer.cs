using LibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.DAL
{
    // creating a new class named dataLayer how`s inheritor from DbContext
    public class DataLayer : DbContext
    {
        public DataLayer(string connectionString) : base(GetOptions(connectionString))
        {
            Database.EnsureCreated();
            seed();
        }
        private void seed()
        {
            if(Libary.Count() > 0)
            {
                return;
            }

            LibaryModdel libaryModdel = new LibaryModdel();
            libaryModdel.genre = "תורה";
            Libary.Add(libaryModdel);
            ShelfModel shelfa = new ShelfModel();
            shelfa.hight = "15";
            shelfa.libary = "תורה";
            shelf.Add(shelfa);
            BookModel book = new BookModel();
            book.name = "תנך";
            book.hight = "10";
            book.shelf = "1";
            Book.Add(book);
            SaveChanges();
            List<BookModel> bookByShelf = new List<BookModel>();

        }

        public DbSet<LibaryModdel> Libary { get; set; }

        public DbSet<ShelfModel> shelf { get; set; }
        public DbSet<BookModel> Book { get; set; }



        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.
                UseSqlServer(new DbContextOptionsBuilder(),
                connectionString).Options;

        }
    }
}
