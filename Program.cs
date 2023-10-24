using System;
using System.IO;

class TicketManager
{
    private string file;

    public TicketManager(string fileName)
    {
        file = fileName;
    }

    public void DisplayMenu()
    {
        string choice;
        do
        {
            Console.WriteLine("1) Read Data from file.");
            Console.WriteLine("2) Create a Ticket.");
            Console.WriteLine("Enter any other key to exit.");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                ReadDataFromFile();
            }
            else if (choice == "2")
            {
                CreateTicket();
            }
        } while (choice == "1" || choice == "2");
    }

    private void ReadDataFromFile()
    {
        if (File.Exists(file))
        {
            int count = 0;
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] arr = line.Split(',');
                    Console.WriteLine("{0},{1},{2},{3},{4},{5}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5]);
                    count += 1;
                }
            }
        }
        else
        {
            Console.WriteLine("File does not exist");
        }
    }

    private void CreateTicket()
    {
        using (StreamWriter sw = new StreamWriter(file, append: true))
        {
            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("Create a Ticket (Y/N)?");
                string resp = Console.ReadLine().ToUpper();
                if (resp != "Y") { break; }
                Console.WriteLine("What type of ticket are you submitting? ");
                string TicketID = Console.ReadLine();
                Console.WriteLine("Summary of ticket: ");
                string Summary = Console.ReadLine();
                Console.WriteLine("Priority Status: ");
                string Status = Console.ReadLine();
                Console.WriteLine("Who is submitting the ticket? ");
                string Submitter = Console.ReadLine();
                Console.WriteLine("Who is assigned to this ticket? ");
                string Assigned = Console.ReadLine();
                Console.WriteLine("Who is watching over this ticket? ");
                string Watching = Console.ReadLine();

                sw.WriteLine("This is a {0} ticket,{1},{2},{3},{4},{5}", TicketID, Summary, Status, Submitter, Assigned, Watching);
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string file = "Tickets.csv";
        TicketManager ticketManager = new TicketManager(file);
        ticketManager.DisplayMenu();
    }
}

