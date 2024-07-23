using CoreLayer.Entites;
using Microsoft.EntityFrameworkCore;

namespace InfrastrcutureLayer.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options)
     : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed random data for the Customer entity
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "Mohamed Waleed Hassan", Email = "MohamedWaleedHassan12@gmail.com",Address="ALZaher_ELGiesh Street", PhoneNumber = "01095494490" },
                new Customer { Id = 2, Name = "NewUser2", Email = "NewUser2@gmail.com", Address = "ALZaher_ELGiesh Street", PhoneNumber = "01111112222" },
                new Customer { Id = 3, Name = "NewUser3", Email = "NewUser3@gmail.com", Address = "Cairo", PhoneNumber = "01111112222" },
                new Customer { Id = 4, Name = "NewUser4", Email = "NewUser4@gmail.com", Address = "Cairo", PhoneNumber = "01111112222" },
                new Customer { Id = 5, Name = "NewUser5", Email = "NewUser5@gmail.com", Address = "Cairo", PhoneNumber = "01111112222" },
                new Customer { Id = 6, Name = "NewUser6", Email = "NewUser6@gmail.com", Address = "Cairo", PhoneNumber = "01111112222" }
            // Add more seed data here if needed
            );
            modelBuilder.Entity<Customer>()
           .HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
