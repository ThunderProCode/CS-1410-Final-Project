using System.Text.Json;

public class DataStore
{
    private const string MenuFileName = "menu.json";
    private const string OrdersFileName = "orders.json";

    public void SaveMenu(Menu menu)
    {
        string jsonData = JsonSerializer.Serialize(menu);
        File.WriteAllText(MenuFileName, jsonData);
    }

    public Menu LoadMenu()
    {
        if (File.Exists(MenuFileName))
        {
            string jsonData = File.ReadAllText(MenuFileName);
            return JsonSerializer.Deserialize<Menu>(jsonData);
        }
        return new Menu(); // Return an empty menu if the file doesn't exist
    }

    public void SaveOrders(List<Order> orders)
    {
        string jsonData = JsonSerializer.Serialize(orders);
        File.WriteAllText(OrdersFileName, jsonData);
    }

    public List<Order> LoadOrders()
    {
        if (File.Exists(OrdersFileName))
        {
            string jsonData = File.ReadAllText(OrdersFileName);
            return JsonSerializer.Deserialize<List<Order>>(jsonData);
        }
        return new List<Order>(); // Return an empty list if the file doesn't exist
    }
}
