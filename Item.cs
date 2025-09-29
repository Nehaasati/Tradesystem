namespace App
{
    // Class to represent an item
    public class Item
    {
        public string Name;        // Item name
        public string Description; // Item description

        // Constructor to initialize item
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        // Display item details
        public void ShowItem()
        {
            System.Console.WriteLine("Item: " + Name);
            System.Console.WriteLine("Description: " + Description);
        }
    }
}
