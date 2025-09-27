namespace App;

public class User
{
    
public string Username { get; private set; }
private string Password;
public List<Item> Items { get; private set; }


public User(string username, string password)
{
Username = username;
Password = password;
Items = new List<Item>();
}


// Basic login method
public bool Login(string username, string password)
{
return Username == username && Password == password;
}


public void AddItem(Item item)
{
Items.Add(item);
}
}

