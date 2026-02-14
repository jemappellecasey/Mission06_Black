using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mission06.Data;
using Mission06.Models;

namespace Mission06.Controllers;

public class MovieController : Controller
{
    private readonly MovieCollectionDbContext _context;

    public MovieController(MovieCollectionDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Add()
    {
        ViewBag.Categories = new SelectList(_context.Categories.OrderBy(c => c.Name), "CategoryId", "Name");
        return View(new Movie { Title = "", Director = "", Rating = "" });
    }

    [HttpPost]
    public IActionResult Add(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Movie added to the collection successfully!";
            return RedirectToAction("Add");
        }

        ViewBag.Categories = new SelectList(_context.Categories.OrderBy(c => c.Name), "CategoryId", "Name", movie.CategoryId);
        return View(movie);
    }
}
