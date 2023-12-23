using BookHouse.Areas.Identity.Data;
using BookHouse.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookHouse.Data;

public class BookHouseDbContext : IdentityDbContext<BookHouseUser>
{
    public DbSet<Book> Books { get; set; }
    public BookHouseDbContext(DbContextOptions<BookHouseDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
