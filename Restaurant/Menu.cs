[Serializable]
public class Menu
{
    public List<MenuItem> Items { get; set; }
    public int nextItemId { get; set; } // Keep track of the next available ID for new items

    public Menu()
    {
        Items = new List<MenuItem>();
        nextItemId = 1; // Start with ID 1
    }

    public void AddMenuItem(MenuItem item)
    {
        // Assign the next available ID to the new item
        item.Id = nextItemId;
        this.Items.Add(item);
    }

    public void UpdateMenuItem(MenuItem updatedItem)
    {
        // Find the menu item with the same Id in the list
        MenuItem existingItem = Items.FirstOrDefault(item => item.Id == updatedItem.Id);

        if (existingItem != null)
        {
            // Update the properties of the existing item
            existingItem.Name = updatedItem.Name;
            existingItem.Description = updatedItem.Description;
            existingItem.Price = updatedItem.Price;

            Console.WriteLine("Menu item updated successfully.");
        }
        else
        {
            Console.WriteLine("Menu item with the specified Id not found. Update failed.");
        }
    }

    public void RemoveMenuItem(MenuItem item)
    {
        this.Items.Remove(item);
    }

    public void DisplayMenu()
    {
        if (Items.Count == 0)
        {
            Console.WriteLine("Menu is currently empty.");
            return;
        }

        Console.WriteLine("======================== Menu ======================== ");

        // Calculate the column widths
        int idWidth = Math.Max(Items.Max(item => item.Id.ToString().Length), 4); // Minimum width of 4 for "Id"
        int nameWidth = Math.Max(Items.Max(item => item.Name.Length), 5); // Minimum width of 5 for "Name"
        int priceWidth = Math.Max(Items.Max(item => item.Price.ToString("C").Length), 6); // Minimum width of 6 for "Price"

        // Display the table header
        Console.WriteLine($"| {"Id".PadRight(idWidth)} | {"Name".PadRight(nameWidth)} | {"Price".PadRight(priceWidth)} | Description");

        // Display the separator line
        Console.WriteLine(new string('-', idWidth + nameWidth + priceWidth + 15));

        // Display each menu item in the table
        foreach (var item in Items)
        {
            Console.WriteLine($"| {item.Id.ToString().PadRight(idWidth)} | {item.Name.PadRight(nameWidth)} | {item.Price.ToString("C").PadRight(priceWidth)} | {item.Description}");
        }

        // Display the end line
        Console.WriteLine(new string('-', idWidth + nameWidth + priceWidth + 15));
    }
    public void IncrementNextItemId()
    {
        nextItemId++;
    }

}
