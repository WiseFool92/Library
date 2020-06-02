using System.Collections.Generic;

namespace Library.Models
{
  public class Book
  {
    public Book()
    {
      this.Catalogs = new HashSet<CatalogBook>();
    }
    public int BookId { get; set; }
    public string Title { get; set; }
    public virtual ApplicationUser User { get; set; }
    public ICollection<CatalogBook> Catalogs { get; }
  }
}