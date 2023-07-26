public class ConsoleManager
{
    public void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Restaurant Ordering System!");
    }

    public void DisplayMainMenu()
    {
        Console.WriteLine("\nSelect an option:");
        Console.WriteLine("1. View Menu");
        Console.WriteLine("2. Place Order");
        Console.WriteLine("3. Pay for Order");
        Console.WriteLine("4. Track Order Status");
        Console.WriteLine("5. Staff Options");
        Console.WriteLine("6. Exit");
    }

    public int GetMainMenuOption()
    {
        return GetInputInt("Enter option number: ");
    }

    public void DisplayStaffOptions()
    {
        Console.WriteLine("\nStaff Options:");
        Console.WriteLine("1. Add Menu Item");
        Console.WriteLine("2. Update Menu Item");
        Console.WriteLine("3. Remove Menu Item");
        Console.WriteLine("4. View All Orders");
        Console.WriteLine("5. Back to Main Menu");
    }

    public int GetStaffOption()
    {
        return GetInputInt("Enter option number: ");
    }

    public void DisplayMenu(Menu menu)
    {
        int idWidth = menu.Items.Count > 0 ? Math.Max(menu.Items.Max(item => item.Id.ToString().Length), "ID".Length) : "ID".Length;
        int nameWidth = menu.Items.Count > 0 ? Math.Max(menu.Items.Max(item => item.Name.Length), "Name".Length) : "Name".Length;
        int descriptionWidth = menu.Items.Count > 0 ? Math.Max(menu.Items.Max(item => item.Description.Length), "Description".Length) : "Description".Length;
        int priceWidth = menu.Items.Count > 0 ? Math.Max(menu.Items.Max(item => item.Price.ToString("F2").Length + 1), "Price".Length) : "Price".Length; // +1 for the "$"

        int totalWidth = idWidth + nameWidth + descriptionWidth + priceWidth + 9; // Adding 9 for column spacings

        Console.WriteLine(new string('=', totalWidth));
        Console.WriteLine($"{CenterString("Menu", totalWidth)}");
        Console.WriteLine(new string('=', totalWidth));
        Console.WriteLine("{0," + idWidth + "} | {1,-" + nameWidth + "} | {2,-" + descriptionWidth + "} | {3," + priceWidth + "}", "ID", "Name", "Description", "Price");
        foreach (var menuItem in menu.Items)
        {
            Console.WriteLine("{0," + idWidth + "} | {1,-" + nameWidth + "} | {2,-" + descriptionWidth + "} | {3," + priceWidth + ":F2}", menuItem.Id, menuItem.Name, menuItem.Description, menuItem.Price);
        }
        Console.WriteLine(new string('=', totalWidth));
    }

    private string CenterString(string text, int totalWidth)
    {
        int spaces = totalWidth - text.Length;
        return new string(' ', spaces / 2) + text + new string(' ', spaces - (spaces / 2));
    }

    public void DisplayOrderDetails(Order order)
    {
        Console.WriteLine($"Order ID: {order.OrderId}");
        Console.WriteLine("===== Order Details =====");
        Console.WriteLine("ID\tName\tDescription\tPrice");
        foreach (var item in order.OrderedItems)
        {
            Console.WriteLine($"{item.Id}\t{item.Name}\t{item.Description}\t{item.Price}");
        }
        Console.WriteLine("===========================");
        Console.WriteLine($"Total Price: {order.TotalAmount}");
        Console.WriteLine($"Order Status: {order.IsPaid}");
    }

    public string GetMenuItemName()
    {
        Console.Write("Enter the Name of the new menu item: ");
        return Console.ReadLine();
    }

    public string GetMenuItemDescription()
    {
        Console.Write("Enter the Description of the new menu item: ");
        return Console.ReadLine();
    }

    public double GetMenuItemPrice()
    {
        return GetInputDouble("Enter the Price of the new menu item: ");
    }

    public int GetMenuItemId()
    {
        return GetInputInt("Enter the Id of the menu item: ");
    }

    public int GetOrderId()
    {
        return GetInputInt("Enter the Order ID: ");
    }

    public void DisplayPaymentSuccessMessage()
    {
        Console.WriteLine("Payment successful. Order has been paid.");
    }

    public void DisplayPaymentFailureMessage()
    {
        Console.WriteLine("Payment failed. Please try again.");
    }

    // Helper method to get integer input from the user
    private int GetInputInt(string prompt = "")
    {
        Console.Write(prompt);
        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.Write("Invalid input. Please enter a valid number: ");
        }
        return input;
    }

    // Helper method to get double input from the user
    private double GetInputDouble(string prompt = "")
    {
        Console.Write(prompt);
        double input;
        while (!double.TryParse(Console.ReadLine(), out input))
        {
            Console.Write("Invalid input. Please enter a valid number: ");
        }
        return input;
    }

    public string GetStaffKey()
    {
        Console.Write("Enter the Staff Key: ");
        return Console.ReadLine();
    }

    public void DisplayAllOrders(List<Order> orders)
    {
        Console.WriteLine("===== All Orders =====");
        foreach (var order in orders)
        {
            Console.WriteLine($"Order ID: {order.OrderId}, Status: {order.IsPaid}, Total Price: {order.TotalAmount}");
        }
        Console.WriteLine("=======================");
    }

    public void DisplayReturnToMainMenuMessage()
    {
        Console.WriteLine("Returning to the main menu.");
    }

    public void DisplayInvalidOptionMessage()
    {
        Console.WriteLine("Invalid option. Please try again.");
    }

    public void DisplayInvalidStaffKeyMessage()
    {
        Console.WriteLine("Invalid staff key. Access denied.");
    }
}