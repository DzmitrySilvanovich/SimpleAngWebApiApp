using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using WebApiAuthCRUD.DAL.Domains;

namespace WebApiAuthCRUD.DAL.Repositories
{
    public class ApplicationContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; } = null!;
        
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            if (!Database.GetService<IRelationalDatabaseCreator>().Exists())
            {
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message), new[] { DbLoggerCategory.Database.Command.Name },
                      LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                   new Book
                   {
                       Id = 1,
                       Author = "This is Aithor",
                       Title = "This is title"
                   });
        }
    }
}
