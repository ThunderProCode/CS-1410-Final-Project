public class MenuItemFactory
{
    private Menu menu;

    public MenuItemFactory(Menu menu)
    {
        this.menu = menu;
    }

    public MenuItem CreateMenuItem(string name, string description, double price)
    {
        MenuItem menuItem = new MenuItem(name, description, price);

        // Assign the next available ID to the new item
        menuItem.Id = menu.nextItemId;
        menu.IncrementNextItemId(); // Increment the next available ID for the next item

        return menuItem;
    }
}
