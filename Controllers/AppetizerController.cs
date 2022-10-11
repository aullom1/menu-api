using Microsoft.AspNetCore.Mvc;

namespace menu_api.Controllers;

[ApiController]
[Route("[controller]")]
public class AppetizerController : ControllerBase
{
    private static readonly string[] Appetizers = new[]
    {
        "Cheese Curds", "Rattlesnake Bites", "Irish Egg Rolls", "Fried Pickles"
    };

    private readonly ILogger<AppetizerController> _logger;

    public AppetizerController(ILogger<AppetizerController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetAppetizers")]
    public IEnumerable<MenuItem> Get()
    {
        // _logger.LogInformation("Hi there");
        
        var items = new List<MenuItem>();
        foreach (var item in Appetizers) {
            items.Add(new MenuItem() {
                Name = item,
                Description = "Happy hour special!",
                Price = 9.99m
            });
        }
        return items.ToArray();
    }
}
