[Serializable]
public class MenuItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

    // Constructor to initialize a new MenuItem with a unique ID
    public MenuItem(string name, string description, double price)
    {
        Id = 0; // The ID will be updated by the Menu class when the item is added
        Name = name;
        Description = description;
        Price = price;
    }
}
