public interface IMenuItemFactory
{
    MenuItem CreateMenuItem(string name, string description, double price);
}