namespace App
{
    using System.Collections.Generic;

    // Class to manage the trading system
    public class TradeSystem
    {
        public List<User> Users;
        public List<Trade> Trades;

        // Constructor
        public TradeSystem()
        {
            Users = new List<User>();
            Trades = new List<Trade>();
        }

        // Register new user
        public void RegisterUser(string username, string password)
        {
            Users.Add(new User(username, password));
            System.Console.WriteLine("User registered successfully!");
        }

        // Find user by username
        public User FindUser(string username)
        {
            foreach (var user in Users)
            {
                if (user.Username == username)
                    return user;
            }
            return null;
        }

        // Show all items from other users
        public void ShowAllItems(User currentUser)
        {
            foreach (var user in Users)
            {
                if (user != currentUser)
                {
                    System.Console.WriteLine("User: " + user.Username);
                    user.ShowItems();
                }
            }
        }

        // Create trade request
        public void CreateTrade(User sender, User receiver, Item offered, Item requested)
        {
            Trade newTrade = new Trade(sender, receiver, offered, requested);
            Trades.Add(newTrade);
            sender.MyTrades.Add(newTrade);
            receiver.MyTrades.Add(newTrade);
            System.Console.WriteLine("Trade request sent!");
        }

        // Show trades for a user
        public void ShowTrades(User user)
        {
            foreach (var trade in user.MyTrades)
            {
                trade.ShowTrade();
                System.Console.WriteLine("------------------");
            }
        }

        // Accept trade
        public void AcceptTrade(Trade trade)
        {
            trade.Status = TradeStatus.Accepted;

            // Swap items
            trade.Sender.MyItems.Remove(trade.ItemOffered);
            trade.Receiver.MyItems.Remove(trade.ItemRequested);

            trade.Sender.MyItems.Add(trade.ItemRequested);
            trade.Receiver.MyItems.Add(trade.ItemOffered);

            System.Console.WriteLine("Trade accepted and items exchanged!");
        }

        // Deny trade
        public void DenyTrade(Trade trade)
        {
            trade.Status = TradeStatus.Denied;
            System.Console.WriteLine("Trade denied.");
        }
    }
}

