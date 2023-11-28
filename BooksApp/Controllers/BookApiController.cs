using BooksAppData;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Controllers;

[Route("api/books")]
[ApiController]
public class BookApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookApiController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetFiltered(string? filter)
    {
        filter = filter?.ToLower() ?? "";
        
        return Ok(
            _context.Books
                .Where(o => o.Title != null && o.Title.ToLower().Contains(filter))
                .Select(o => new { o.Title, o.Id })
                .ToList()
        );
    }
}