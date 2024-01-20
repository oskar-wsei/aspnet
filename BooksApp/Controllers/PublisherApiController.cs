using BooksAppData;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Controllers;

[Route("api/publishers")]
[ApiController]
public class PublisherApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public PublisherApiController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetFiltered(string? filter)
    {
        filter = filter?.ToLower() ?? "";

        return Ok(
            _context.Publishers
                .Where(o => o.Name != null && o.Name.ToLower().Contains(filter))
                .Select(o => new { o.Name, o.Id })
                .ToList()
        );
    }
}