[TestFixture]
public class MenuItemTests
{
    [Test]
    public void MenuItem_Initialization_Should_Set_Properties_Correctly()
    {
        // Test the initialization of MenuItem properties
        MenuItem menuItem = new MenuItem("Burger", "Delicious beef burger", 9.99);

        Assert.AreEqual("Burger", menuItem.Name);
        Assert.AreEqual("Delicious beef burger", menuItem.Description);
        Assert.AreEqual(9.99, menuItem.Price);
    }
}
