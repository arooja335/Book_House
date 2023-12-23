using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookHouse.Models; // Add the namespace for your ViewModel
using BookHouse.Data;
using FuzzyString;
using System.Linq;

[Authorize] // Ensure the user is logged in to access these actions
public class BookController : Controller
{
    private readonly BookHouseDbContext _context;

    public BookController(BookHouseDbContext context)
    {
        _context = context;
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [HttpPost]
    public IActionResult Create(Book model)
    {
        if (ModelState.IsValid)
        {
            _context.Books.Add(model);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        return View(model);
    }
    //-----------------Search--------------------



    [HttpGet]
    [AllowAnonymous]
    public IActionResult Search(string searchString)
    {
        var allBooks = _context.Books.ToList();

        var matchingBooks = allBooks
            .Where(book =>
                book.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                book.Author.Contains(searchString, StringComparison.OrdinalIgnoreCase)
            )
            .ToList();

        ViewBag.SearchString = searchString;

        if (matchingBooks.Count == 0)
        {
            // No books found, display a message or handle it as needed
            ViewBag.NoBooksFound = "No books found.";
        }

        return View(matchingBooks);
    }



     [HttpPost]
    public IActionResult SearchPost(string searchString)
    {
        // Additional logic for handling POST requests, if needed
        // For example, you might want to perform a more complex search or filtering

        // Redirect to the GET action to display the results
        return RedirectToAction("Search", new { searchString });
    }




}