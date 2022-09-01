using Microsoft.AspNetCore.Mvc;

namespace menu_api.Controllers;

[ApiController]
[Route("[controller]")]
public class MenuController : ControllerBase
{
    private static readonly string[] Appetizers = new[]
    {
        "Cheese Curds", "Rattlesnake Bites", "Irish Egg Rolls"
    };

    private readonly ILogger<MenuController> _logger;

    public MenuController(ILogger<MenuController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetMenu")]
    public Menu Get()
    {
        var menu = new Menu();
        
        menu.Appetizers.Add(new MenuItem() {Name = "Cheese Curds"});
        menu.Appetizers.Add(new MenuItem() {Name = "Rattlesnake Bites"});
        menu.Appetizers.Add(new MenuItem() {Name = "Irish Egg Rolls"});

        menu.Entrees.Add(new MenuItem() {Name = "Gator Salad"});
        menu.Entrees.Add(new MenuItem() {Name = "Gator Burger"});
        menu.Entrees.Add(new MenuItem() {Name = "Gator Tails"});

        return menu;
    }
}
