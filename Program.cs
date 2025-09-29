namespace App
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            TradeSystem system = new TradeSystem();

            while (true)
            {
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();
                    system.RegisterUser(username, password);
                }
                else if (choice == "2")
                {
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();

                    User currentUser = system.FindUser(username);
                    if (currentUser != null && currentUser.Login(username, password))
                    {
                        Console.WriteLine("Login successful!");
                        UserMenu(system, currentUser);
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password.");
                    }
                }
                else if (choice == "3")
                {
                    break;
                }
            }
        }

        static void UserMenu(TradeSystem system, User user)
        {
            while (true)
            {
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. View My Items");
                Console.WriteLine("3. View Other Users' Items");
                Console.WriteLine("4. Request Trade");
                Console.WriteLine("5. View My Trades");
                Console.WriteLine("6. Logout");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Item name: ");
                    string name = Console.ReadLine();
                    Console.Write("Item description: ");
                    string desc = Console.ReadLine();
                    user.AddItem(new Item(name, desc));
                    Console.WriteLine("Item added!");
                }
                else if (choice == "2")
                {
                    user.ShowItems();
                }
                else if (choice == "3")
                {
                    system.ShowAllItems(user);
                }
                else if (choice == "4")
                {
                    Console.Write("Enter username to trade with: ");
                    string receiverName = Console.ReadLine();
                    User receiver = system.FindUser(receiverName);
                    if (receiver != null)
                    {
                        Console.WriteLine("Your items:");
                        user.ShowItems();
                        Console.Write("Choose your item to offer (name): ");
                        string offerName = Console.ReadLine();

                        Item offered = null;
                        foreach (var item in user.MyItems)
                        {
                            if (item.Name == offerName)
                            {
                                offered = item;
                                break;
                            }
                        }

                        Console.WriteLine(receiver.Username + "'s items:");
                        receiver.ShowItems();
                        Console.Write("Choose item to request (name): ");
                        string requestName = Console.ReadLine();

                        Item requested = null;
                        foreach (var item in receiver.MyItems)
                        {
                            if (item.Name == requestName)
                            {
                                requested = item;
                                break;
                            }
                        }

                        if (offered != null && requested != null)
                        {
                            system.CreateTrade(user, receiver, offered, requested);
                        }
                        else
                        {
                            Console.WriteLine("Invalid item selection.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("User not found.");
                    }
                }
                else if (choice == "5")
                {
                    system.ShowTrades(user);

                    Console.Write("Do you want to accept or deny a trade? (type Accept/Deny/No): ");
                    string action = Console.ReadLine();
                    if (action == "Accept" || action == "Deny")
                    {
                        Console.Write("Enter trade sender username: ");
                        string senderName = Console.ReadLine();
                        Trade selectedTrade = null;
                        foreach (var trade in user.MyTrades)
                        {
                            if (trade.Sender.Username == senderName && trade.Status == TradeStatus.Pending)
                            {
                                selectedTrade = trade;
                                break;
                            }
                        }

                        if (selectedTrade != null)
                        {
                            if (action == "Accept")
                                system.AcceptTrade(selectedTrade);
                            else
                                system.DenyTrade(selectedTrade);
                        }
                        else
                        {
                            Console.WriteLine("No pending trade found from that user.");
                        }
                    }
                }
                else if (choice == "6")
                {
                    break;
                }
            }
        }
    }
}

