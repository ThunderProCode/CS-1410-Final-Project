[TestFixture]
public class MenuTests
{
    [Test]
    public void Menu_AddItem_Should_Add_Item_Correctly()
    {
        // Test adding an item to the menu
        Menu menu = new Menu();
        MenuItem menuItem = new MenuItem("Burger", "Delicious beef burger", 9.99);

        menu.AddMenuItem(menuItem);

        Assert.Contains(menuItem, menu.Items);
    }

    [Test]
    public void Menu_RemoveItem_Should_Remove_Item_Correctly()
    {
        // Test removing an item from the menu
        Menu menu = new Menu();
        MenuItem menuItem = new MenuItem("Burger", "Delicious beef burger", 9.99);
        menu.AddMenuItem(menuItem);

        menu.RemoveMenuItem(menuItem);

        Assert.IsFalse(menu.Items.Contains(menuItem));
    }
}
