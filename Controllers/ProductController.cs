using Microsoft.AspNetCore.Mvc;
using CrudApp.Data;
using CrudApp.Models;
using System.Linq;


public class ProductController : Controller
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Products.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (!ModelState.IsValid)
        {
            return View(product);
        }

        _context.Products.Add(product);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null) return NotFound();

        return View(product);
    }

    [HttpPost]
    public IActionResult Edit(Product product)
    {
        var existing = _context.Products.Find(product.Id);

        if (existing == null)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(product);
        }

        existing.Name = product.Name;
        existing.Brand = product.Brand;
        existing.Price = product.Price;
        existing.Category = product.Category;
        existing.Shade = product.Shade;
        existing.Quantity = product.Quantity;
        existing.ExpirationDate = product.ExpirationDate;
        existing.Description = product.Description;

        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null) return NotFound();

        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var product = _context.Products.Find(id);

        if (product == null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}