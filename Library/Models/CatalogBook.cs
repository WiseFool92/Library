namespace Library.Models
{
  public class CatalogBook
  {
    public int CatalogBookId { get; set; }
    public int BookId { get; set; }
    public int CatalogId { get; set; }
    public Book Book { get; set; }
    public Catalog Catalog { get; set; }
  }
}