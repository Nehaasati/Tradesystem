namespace App;
public class Item
{
public string Name { get; set; }
public string Description { get; set; }


public Item(string name, string description)
{
Name = name;
Description = description;
}


public override string ToString()
{
return $"Item: {Name}, Description: {Description}";
}
}