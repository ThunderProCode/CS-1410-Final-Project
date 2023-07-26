[Serializable]
public class Order
{
     private static int nextOrderId = 1; // Keep track of the next available order ID
    public int OrderId { get; set; }
    public List<MenuItem> OrderedItems { get; private set; }
    public double TotalAmount { get; private set; }
    public bool IsPaid { get; set; }
    // Add other relevant properties like OrderTime, Status, etc.

    public Order()
    {
        OrderId = nextOrderId;
        nextOrderId++; // Increment the next available order ID for the next order
        OrderedItems = new List<MenuItem>();
        TotalAmount = 0;
        IsPaid = false;
    }

    public void AddToOrder(MenuItem item)
    {
        OrderedItems.Add(item);
        CalculateTotalAmount();
        Console.WriteLine($"{item.Name} added to the order.");
    }

    public void RemoveFromOrder(MenuItem item)
    {
        bool removed = OrderedItems.Remove(item);
        if (removed)
        {
            CalculateTotalAmount();
            Console.WriteLine($"{item.Name} removed from the order.");
        }
        else
        {
            Console.WriteLine($"{item.Name} not found in the order.");
        }
    }

    public void CalculateTotalAmount()
    {
        TotalAmount = OrderedItems.Sum(item => item.Price);
    }

    public void DisplayOrderDetails()
    {
        Console.WriteLine($"Order ID: {OrderId}");
        Console.WriteLine("===== Ordered Items =====");
        if (OrderedItems.Count == 0)
        {
            Console.WriteLine("No items in the order.");
        }
        else
        {
            foreach (var item in OrderedItems)
            {
                Console.WriteLine($"Item: {item.Name}, Price: ${item.Price}");
            }
        }
        Console.WriteLine("=========================");
        Console.WriteLine($"Total Amount: ${TotalAmount}");
        Console.WriteLine($"Order Status: {(IsPaid ? "Paid" : "Unpaid")}");
        // Add other relevant order details like OrderTime, Status, etc.
    }
}
