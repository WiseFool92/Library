using Microsoft.AspNetCore.Mvc;
using Library.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
  public class CatalogsController : Controller
  {
    private readonly LibraryContext _db;

    public CatalogsController(LibraryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Catalog> model = _db.Catalogs.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Catalog catalog)
    {
      _db.Catalogs.Add(catalog);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisCatalog = _db.Catalogs
      .Include(Catalogs => Catalogs.Books)
      .ThenInclude(join => join.Book)
      .FirstOrDefault(Catalogs => Catalogs.CatalogId == id);
      return View(thisCatalog);
    }

    public ActionResult Edit(int id)
    {
      var thisCatalog = _db.Catalogs.FirstOrDefault(catalog => catalog.CatalogId == id);
      return View(thisCatalog);
    }

    public ActionResult Edit(Catalog catalog)
    {
      _db.Entry(catalog).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisCatalog = _db.Catalogs.FirstOrDefault(catalog => catalog.CatalogId == id);
      return View(thisCatalog);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisCatalog = _db.Catalogs.FirstOrDefault(catalog => catalog.CatalogId == id);
      _db.Catalogs.Remove(thisCatalog);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}