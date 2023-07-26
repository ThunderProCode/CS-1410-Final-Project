[TestFixture]
public class OrderTests
{
    [Test]
    public void Order_AddItem_Should_Add_Item_Correctly()
    {
        // Test adding an item to the order
        Order order = new Order();
        MenuItem menuItem = new MenuItem("Burger", "Delicious beef burger", 9.99);

        order.AddToOrder(menuItem);

        Assert.Contains(menuItem, order.OrderedItems);
    }

    [Test]
    public void Order_RemoveItem_Should_Remove_Item_Correctly()
    {
        // Test removing an item from the order
        Order order = new Order();
        MenuItem menuItem = new MenuItem("Burger", "Delicious beef burger", 9.99);
        order.AddToOrder(menuItem);

        order.RemoveFromOrder(menuItem);

        Assert.IsFalse(order.OrderedItems.Contains(menuItem));
    }
}
