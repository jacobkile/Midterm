class Program
{
    static void Main(string[] args)
    {
        string file = "Tickets.csv"; // Generic Ticket file
        TicketManager ticketManager = new TicketManager(file);
        ticketManager.DisplayMenu();
    }
}
