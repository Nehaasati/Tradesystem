namespace App
{
    // Enum for trade status
    public enum TradeStatus
    {
        Pending,
        Accepted,
        Denied
    }

    // Class to represent a trade
    public class Trade
    {
        public User Sender;      // Who requested the trade
        public User Receiver;    // Who receives the trade request
        public TradeStatus Status; 
        public Item ItemOffered; // Item sender offers
        public Item ItemRequested; // Item requested from receiver

        // Constructor
        public Trade(User sender, User receiver, Item offered, Item requested)
        {
            Sender = sender;
            Receiver = receiver;
            ItemOffered = offered;
            ItemRequested = requested;
            Status = TradeStatus.Pending; // Default status
        }

        // Display trade info
        public void ShowTrade()
        {
            System.Console.WriteLine("Trade Request:");
            System.Console.WriteLine("From: " + Sender.Username);
            System.Console.WriteLine("To: " + Receiver.Username);
            System.Console.WriteLine("Offered Item: " + ItemOffered.Name);
            System.Console.WriteLine("Requested Item: " + ItemRequested.Name);
            System.Console.WriteLine("Status: " + Status);
        }
    }
}

