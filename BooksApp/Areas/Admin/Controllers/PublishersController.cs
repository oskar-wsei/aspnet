using BooksApp.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "admin")]
public class PublishersController : Controller
{
    private readonly IPublisherService _publisherService;

    public PublishersController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _publisherService.Delete(id);
        return Redirect("/Admin/Publishers");
    }
}