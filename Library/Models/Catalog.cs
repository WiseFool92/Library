using System.Collections.Generic;

namespace Library.Models
{
  public class Catalog
  {
    public Catalog()
    {
      this.Books = new HashSet<CatalogBook>();
    }

    public int CatalogId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<CatalogBook> Books { get; set; }
  }
}