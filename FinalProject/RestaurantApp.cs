public class RestaurantApp
{
    private Menu restaurantMenu;
    private List<Order> orders;
    private ConsoleManager consoleManager;
    private DataStore dataStore;

    public RestaurantApp()
    {
        restaurantMenu = new Menu();
        orders = new List<Order>();
        consoleManager = new ConsoleManager();
        dataStore = new DataStore();
    }

    public void Start()
    {

        // Load menu and orders data from files
        restaurantMenu = dataStore.LoadMenu();
        orders = dataStore.LoadOrders();
        consoleManager.DisplayWelcomeMessage();

        while (true)
        {
            consoleManager.DisplayMainMenu();
            int option = consoleManager.GetMainMenuOption();

            switch (option)
            {
                case 1:
                    Console.Clear();
                    consoleManager.DisplayMenu(restaurantMenu);
                    break;
                case 2:
                    PlaceOrder();
                    break;
                case 3:
                    PayForOrder();
                    break;
                case 4:
                    TrackOrderStatus();
                    break;
                case 5:
                    Console.Clear();
                    StaffOptions();
                    break;
                case 6:
                    Console.WriteLine("Thank you for using the Restaurant Ordering System. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

             // Save menu and orders data before exiting the application
            dataStore.SaveMenu(restaurantMenu);
            dataStore.SaveOrders(orders);
        }
    }

    private void StaffOptions()
    {
        string staffKey = consoleManager.GetStaffKey();

        if (staffKey == "key")
        {
            while (true)
            {
                consoleManager.DisplayStaffOptions();
                int option = consoleManager.GetStaffOption();

                switch (option)
                {
                    case 1:
                        AddMenuItem();
                        break;
                    case 2:
                        UpdateMenuItem();
                        break;
                    case 3:
                        RemoveMenuItem();
                        break;
                    case 4:
                        consoleManager.DisplayAllOrders(orders);
                        break;
                    case 5:
                        consoleManager.DisplayReturnToMainMenuMessage();
                        return;
                    default:
                        consoleManager.DisplayInvalidOptionMessage();
                        break;
                }
            }
        }
        else
        {
            consoleManager.DisplayInvalidStaffKeyMessage();
        }
    }

    private void DisplayMenu()
    {
        restaurantMenu.DisplayMenu();
    }

    private void PlaceOrder()
    {
        // Create a new order for the customer
        Order order = new Order();

        // Assuming you have access to the Customer class and have created a customer instance
        Customer customer = new Customer
        {
            CustomerId = 1,
            Name = "John Doe"
        };

        customer.PlaceOrder(restaurantMenu, order);
        orders.Add(order);
    }

    private void PayForOrder()
    {
        Console.Write("Enter the Order ID to pay for: ");
        int orderId = GetInputInt();

        Order order = orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order != null)
        {
            // Assuming you have access to the Customer class and have created a customer instance
            Customer customer = new Customer
            {
                CustomerId = 1,
                Name = "John Doe"
            };

            customer.PayForOrder(order);
        }
        else
        {
            Console.WriteLine($"Order with ID {orderId} not found.");
        }
    }

    private void TrackOrderStatus()
    {
        Console.Write("Enter the Order ID to track status: ");
        int orderId = GetInputInt();

        Order order = orders.FirstOrDefault(o => o.OrderId == orderId);
        if (order != null)
        {
            // Assuming you have access to the Customer class and have created a customer instance
            Customer customer = new Customer
            {
                CustomerId = 1,
                Name = "John Doe"
            };

            customer.TrackOrderStatus(order);
        }
        else
        {
            Console.WriteLine($"Order with ID {orderId} not found.");
        }
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

    private void AddMenuItem()
    {
        MenuItemFactory menuItemFactory = new MenuItemFactory(restaurantMenu);

        Console.Write("Enter the Name of the new menu item: ");
        string name = Console.ReadLine();

        Console.Write("Enter the Description of the new menu item: ");
        string description = Console.ReadLine();

        Console.Write("Enter the Price of the new menu item: ");
        double price = GetInputDouble();

        MenuItem newItem = menuItemFactory.CreateMenuItem(name, description, price);
        restaurantMenu.AddMenuItem(newItem);
        Console.WriteLine("Menu item added successfully.");
    }

    private void UpdateMenuItem()
    {
        restaurantMenu.DisplayMenu();

        Console.Write("Enter the Id of the menu item to update: ");
        int itemId = GetInputInt();

        MenuItem existingItem = restaurantMenu.Items.FirstOrDefault(item => item.Id == itemId);
        if (existingItem != null)
        {
            Console.WriteLine("Current Menu Item Details:");
            Console.WriteLine($"Name: {existingItem.Name}");
            Console.WriteLine($"Description: {existingItem.Description}");
            Console.WriteLine($"Price: {existingItem.Price}");

            Console.WriteLine("\nWhat do you want to update?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. Description");
            Console.WriteLine("3. Price");
            Console.WriteLine("4. Cancel");

            int option = GetInputInt("Enter option number: ");

            switch (option)
            {
                case 1:
                    Console.Write("Enter the new Name of the menu item: ");
                    existingItem.Name = Console.ReadLine();
                    break;
                case 2:
                    Console.Write("Enter the new Description of the menu item: ");
                    existingItem.Description = Console.ReadLine();
                    break;
                case 3:
                    Console.Write("Enter the new Price of the menu item: ");
                    existingItem.Price = GetInputDouble();
                    break;
                case 4:
                    Console.WriteLine("Update canceled.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Update canceled.");
                    break;
            }

            Console.WriteLine("Menu item updated successfully.");
        }
        else
        {
            Console.WriteLine("Menu item with the specified Id not found. Update failed.");
        }
    }


    private void RemoveMenuItem()
    {
        restaurantMenu.DisplayMenu();

        Console.Write("Enter the Id of the menu item to remove: ");
        int itemId = GetInputInt();

        MenuItem itemToRemove = restaurantMenu.Items.FirstOrDefault(item => item.Id == itemId);
        if (itemToRemove != null)
        {
            restaurantMenu.RemoveMenuItem(itemToRemove);
            Console.WriteLine("Menu item removed successfully.");
        }
        else
        {
            Console.WriteLine("Menu item with the specified Id not found. Remove failed.");
        }
    }

    private void ViewAllOrders()
    {
        if (orders.Count == 0)
        {
            Console.WriteLine("No orders placed yet.");
            return;
        }

        Console.WriteLine("===== All Orders =====");

        foreach (var order in orders)
        {
            order.DisplayOrderDetails();
            Console.WriteLine("=======================");
        }
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

}
