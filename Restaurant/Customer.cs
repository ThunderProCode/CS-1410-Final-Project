using System;

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    // Add other relevant properties like Address, ContactInfo, etc.

    public void PlaceOrder(Menu restaurantMenu, Order order)
    {
        if (restaurantMenu == null)
        {
            Console.WriteLine("Restaurant menu not available. Cannot place the order.");
            return;
        }

        // Display the menu to the customer
        restaurantMenu.DisplayMenu();

        // Add items to the order
        while (true)
        {
            Console.Write("Enter the Id of the menu item to add (or 0 to finish the order): ");
            int itemId = int.Parse(Console.ReadLine());

            if (itemId == 0)
                break;

            MenuItem selectedItem = restaurantMenu.Items.FirstOrDefault(item => item.Id == itemId);

            if (selectedItem != null)
            {
                order.AddToOrder(selectedItem);
            }
            else
            {
                Console.WriteLine("Invalid menu item Id. Please try again.");
            }
        }

        // Display the order details after placing the order
        Console.WriteLine("Order placed successfully. Here are the order details:");
        order.DisplayOrderDetails();
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

     public void PayForOrder(Order order)
    {
        if (order.IsPaid)
        {
            Console.WriteLine("Order has already been paid for.");
            return;
        }

        Console.WriteLine("Select payment method:");
        Console.WriteLine("1. Cash");
        Console.WriteLine("2. Card");

        int option = GetInputInt("Enter payment option number: ");
        PaymentType paymentType = (PaymentType)option;

        PaymentProcessor paymentProcessor = new PaymentProcessor();
        bool paymentResult = paymentProcessor.ProcessPayment(order, paymentType);

        if (paymentResult)
        {
            Console.WriteLine("Payment successful. Order has been paid.");
        }
        else
        {
            Console.WriteLine("Payment failed. Please try again.");
        }
    }

    public void TrackOrderStatus(Order order)
    {
        Console.WriteLine($"Order ID: {order.OrderId}");
        Console.WriteLine($"Order Status: {(order.IsPaid ? "Paid" : "Unpaid")}");
        // Add other relevant order tracking details like OrderTime, Status, etc.
    }
}
