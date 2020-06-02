using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
  public class LibraryContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Catalog> Catalogs { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<CatalogBook> CatalogBook { get; set; }

    public LibraryContext(DbContextOptions options) : base(options) { }
  }
}