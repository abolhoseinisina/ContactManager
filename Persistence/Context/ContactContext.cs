using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
        : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlite(@"Data Source=ContactManagerDB.db");
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ContactManagerDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    FirstName = "Sina",
                    LastName = "Abolhoseini",
                    HomeTelephone = "+98-2177000305",
                    CellPhone = "+98-9172152580",
                    Address = "Tehran, Iran",
                    Email = "abolhoseini.sina@gmail.com",
                    SkypeName = "abolhoseini.sina"
                }
            );
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
