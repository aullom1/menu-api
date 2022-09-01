namespace menu_api;

public class Menu {
    public IList<MenuItem> Appetizers { get; set; } = new List<MenuItem>();

    public IList<MenuItem> Entrees { get; set; } = new List<MenuItem>();
}
