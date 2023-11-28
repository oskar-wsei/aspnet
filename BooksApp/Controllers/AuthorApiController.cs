using BooksAppData;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Controllers;

[Route("api/authors")]
[ApiController]
public class AuthorApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthorApiController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetFiltered(string? filter)
    {
        filter = filter?.ToLower() ?? "";

        return Ok(
            _context.Authors
                .Where(o => (o.FirstName != null && o.FirstName.ToLower().Contains(filter)) ||
                            (o.LastName != null && o.LastName.ToLower().Contains(filter)))
                .Select(o => new { o.FirstName, o.LastName, o.FullName, o.Id })
                .ToList()
        );
    }
}