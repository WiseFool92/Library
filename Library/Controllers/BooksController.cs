using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System;

namespace Library.Controllers
{
  [Authorize]
  public class BooksController : Controller
  {
    private readonly LibraryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public BooksController(UserManager<ApplicationUser> userManager, LibraryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userBooks = _db.Books.Where(entry => entry.User.Id == currentUser.Id);
      return View(userBooks);
    }

    public ActionResult Create()
    {
      ViewBag.CatalogId = new SelectList(_db.Catalogs, "CatalogId", "Name");
      return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(Book book, int CatalogId)
    {
      Console.WriteLine("Hello");
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      book.User = currentUser;
      _db.Books.Add(book);
      if (CatalogId != 0)
      {
        _db.CatalogBook.Add(new CatalogBook() { CatalogId = CatalogId, BookId = book.BookId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisBook = _db.Books
          .Include(book => book.Catalogs)
          .ThenInclude(join => join.Catalog)
          .FirstOrDefault(book => book.BookId == id);
      return View(thisBook);
    }

    public ActionResult Edit(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      ViewBag.CatalogId = new SelectList(_db.Catalogs, "CatalogId", "Name");
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult Edit(Book book, int CatalogId)
    {
      if (CatalogId != 0)
      {
        _db.CatalogBook.Add(new CatalogBook() { CatalogId = CatalogId, BookId = book.BookId });
      }
      _db.Entry(book).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddCatalog(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      ViewBag.CatalogId = new SelectList(_db.Catalogs, "CatalogsId", "Name");
      return View(thisBook);
    }

    [HttpPost]
    public ActionResult AddCatalog(Book book, int CatalogId)
    {
      if (CatalogId != 0)
      {
        _db.CatalogBook.Add(new CatalogBook() { CatalogId = CatalogId, BookId = book.BookId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      return View(thisBook);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisBook = _db.Books.FirstOrDefault(books => books.BookId == id);
      _db.Books.Remove(thisBook);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteCatalog(int joinId)
    {
      var joinEntry = _db.CatalogBook.FirstOrDefault(entry => entry.CatalogBookId == joinId);
      _db.CatalogBook.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet("/search")]
    public ActionResult Search(string search)
    {
      List<Book> model = _db.Books.Include(books => books.Catalogs).ToList();
      Book match = new Book();

      if (!string.IsNullOrEmpty(search))
      {
        foreach(Book book in model)
        {
          if (book.Title == search)
          {
            match = book;
          }
        }
      }
      List<CatalogBook> matches = match.Catalogs.ToList();
      return View(matches);
    }
  }
}
// thisBook.Catalogs = _db.Catalogs.Where(catalog => catalog.BookCatalog == id).ToList();

// matching catalog genre names of books
