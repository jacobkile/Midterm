class Ticket
{
    public string TicketID { get; set; }
    public string Summary { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string Submitter { get; set; }
    public string Assigned { get; set; }
    public string Watching { get; set; }

    public virtual void Display()
    {
        Console.WriteLine("Ticket Type: Generic");
        Console.WriteLine($"TicketID: {TicketID}");
        Console.WriteLine($"Summary: {Summary}");
        Console.WriteLine($"Status: {Status}");
        Console.WriteLine($"Priority: {Priority}");
        Console.WriteLine($"Submitter: {Submitter}");
        Console.WriteLine($"Assigned: {Assigned}");
        Console.WriteLine($"Watching: {Watching}");
    }
}

class BugTicket : Ticket
{
    public string Severity { get; set; }

    public override void Display()
    {
        Console.WriteLine("Ticket Type: Bug/Defect");
        base.Display();
        Console.WriteLine($"Severity: {Severity}");
    }
}

class EnhancementTicket : Ticket
{
    public string Software { get; set; }
    public string Cost { get; set; }
    public string Reason { get; set; }
    public string Estimate { get; set; }

    public override void Display()
    {
        Console.WriteLine("Ticket Type: Enhancement");
        base.Display();
        Console.WriteLine($"Software: {Software}");
        Console.WriteLine($"Cost: {Cost}");
        Console.WriteLine($"Reason: {Reason}");
        Console.WriteLine($"Estimate: {Estimate}");
    }
}

class TaskTicket : Ticket
{
    public string ProjectName { get; set; }
    public string DueDate { get; set; }

    public override void Display()
    {
        Console.WriteLine("Ticket Type: Task");
        base.Display();
        Console.WriteLine($"Project Name: {ProjectName}");
        Console.WriteLine($"Due Date: {DueDate}");
    }
}

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
            Console.WriteLine("2) Create a Bug/Defect Ticket.");
            Console.WriteLine("3) Create an Enhancement Ticket.");
            Console.WriteLine("4) Create a Task Ticket.");
            Console.WriteLine("Enter any other key to exit.");
            choice = Console.ReadLine();

            if (choice == "1")
            {
                string ticketchoice;
                do{
                    Console.WriteLine("1) Bug/Defect Tickets.");
                    Console.WriteLine("2) Enhancement Tickets.");
                    Console.WriteLine("3) Task Tickets.");
                    Console.WriteLine("Enter any other key to exit.");
                    ticketchoice = Console.ReadLine();
                    if (ticketchoice == "1")
                    {
                        ReadDataFromFile("Bug.csv");  
                    }
                    else if (ticketchoice == "2")
                    {
                        ReadDataFromFile("Enhancements.csv");  
                    }
                    else if (ticketchoice == "3")
                    {
                        ReadDataFromFile("Task.csv");  
                    }
                
                } while (ticketchoice == "1" || ticketchoice == "2" || ticketchoice == "3");
    
            }
            else if (choice == "2")
            {
                CreateBugTicket();
            }
            else if (choice == "3")
            {
                CreateEnhancementTicket();
            }
            else if (choice == "4")
            {
                CreateTaskTicket();
            }
        } while (choice == "1" || choice == "2" || choice == "3" || choice == "4");
    }

    private void ReadDataFromFile(string csv)
{
    if (File.Exists(csv))
    {
        int count = 0;
        using (StreamReader sr = new StreamReader(csv))
        {
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] arr = line.Split(',');

                if (csv == "Bug.csv" && arr.Length >= 8)
                {
                    BugTicket bugTicket = new BugTicket
                    {
                        TicketID = arr[0],
                        Severity = arr[1],
                        Summary = arr[2],
                        Status = arr[3],
                        Priority = arr[4],
                        Submitter = arr[5],
                        Assigned = arr[6],
                        Watching = arr[7]
                    };
                    bugTicket.Display();
                }
                else if (csv == "Enhancements.csv" && arr.Length >= 12)
                {
                    EnhancementTicket enhancementTicket = new EnhancementTicket
                    {
                        TicketID = arr[0],
                        Summary = arr[2],
                        Status = arr[3],
                        Priority = arr[4],
                        Submitter = arr[5],
                        Assigned = arr[6],
                        Watching = arr[7],
                        Software = arr[8],
                        Cost = arr[9],
                        Reason = arr[10],
                        Estimate = arr[11]
                    };
                    enhancementTicket.Display();
                }
                else if (csv == "Task.csv" && arr.Length >= 10)
                {
                    TaskTicket taskTicket = new TaskTicket
                    {
                        TicketID = arr[0],
                        Summary = arr[2],
                        Status = arr[3],
                        Priority = arr[4],
                        Submitter = arr[5],
                        Assigned = arr[6],
                        Watching = arr[7],
                        ProjectName = arr[8],
                        DueDate = arr[9]
                    };
                    taskTicket.Display();
                }
                count += 1;
            }
        }
    }
    else
    {
        Console.WriteLine("File does not exist");
    }
}


    private static void CreateBugTicket()
    {
        BugTicket bugTicket = new BugTicket();

        Console.WriteLine("Creating a Bug/Defect Ticket:");
        Console.Write("TicketID: ");
        bugTicket.TicketID = Console.ReadLine();

        Console.Write("Summary: ");
        bugTicket.Summary = Console.ReadLine();

        Console.Write("Status: ");
        bugTicket.Status = Console.ReadLine();

        Console.Write("Priority: ");
        bugTicket.Priority = Console.ReadLine();

        Console.Write("Submitter: ");
        bugTicket.Submitter = Console.ReadLine();

        Console.Write("Assigned: ");
        bugTicket.Assigned = Console.ReadLine();

        Console.Write("Watching: ");
        bugTicket.Watching = Console.ReadLine();

        Console.Write("Severity: ");
        bugTicket.Severity = Console.ReadLine();

        using StreamWriter sw = new StreamWriter("Bug.csv", append: true);
        sw.WriteLine($"{bugTicket.TicketID},This is a bug/defect,{bugTicket.Summary},{bugTicket.Status},{bugTicket.Priority},{bugTicket.Submitter},{bugTicket.Assigned},{bugTicket.Watching},{bugTicket.Severity}");
    }

    private static void CreateEnhancementTicket()
    {
        EnhancementTicket enhancementTicket = new EnhancementTicket();

        Console.WriteLine("Creating an Enhancement Ticket:");
        Console.Write("TicketID: ");
        enhancementTicket.TicketID = Console.ReadLine();

        Console.Write("Summary: ");
        enhancementTicket.Summary = Console.ReadLine();

        Console.Write("Status: ");
        enhancementTicket.Status = Console.ReadLine();

        Console.Write("Priority: ");
        enhancementTicket.Priority = Console.ReadLine();

        Console.Write("Submitter: ");
        enhancementTicket.Submitter = Console.ReadLine();

        Console.Write("Assigned: ");
        enhancementTicket.Assigned = Console.ReadLine();

        Console.Write("Watching: ");
        enhancementTicket.Watching = Console.ReadLine();

        Console.Write("Software: ");
        enhancementTicket.Software = Console.ReadLine();

        Console.Write("Cost: ");
        enhancementTicket.Cost = Console.ReadLine();

        Console.Write("Reason: ");
        enhancementTicket.Reason = Console.ReadLine();

        Console.Write("Estimate: ");
        enhancementTicket.Estimate = Console.ReadLine();

        using StreamWriter sw = new StreamWriter("Enhancements.csv", append: true);
        sw.WriteLine($"{enhancementTicket.TicketID},This is an Enhancement,{enhancementTicket.Summary},{enhancementTicket.Status},{enhancementTicket.Priority},{enhancementTicket.Submitter},{enhancementTicket.Assigned},{enhancementTicket.Watching},{enhancementTicket.Software},{enhancementTicket.Cost},{enhancementTicket.Reason},{enhancementTicket.Estimate}");
    }

    private static void CreateTaskTicket()
    {
        TaskTicket taskTicket = new TaskTicket();

        Console.WriteLine("Creating a Task Ticket:");
        Console.Write("TicketID: ");
        taskTicket.TicketID = Console.ReadLine();

        Console.Write("Summary: ");
        taskTicket.Summary = Console.ReadLine();

        Console.Write("Status: ");
        taskTicket.Status = Console.ReadLine();

        Console.Write("Priority: ");
        taskTicket.Priority = Console.ReadLine();

        Console.Write("Submitter: ");
        taskTicket.Submitter = Console.ReadLine();

        Console.Write("Assigned: ");
        taskTicket.Assigned = Console.ReadLine();

        Console.Write("Watching: ");
        taskTicket.Watching = Console.ReadLine();

        Console.Write("Project Name: ");
        taskTicket.ProjectName = Console.ReadLine();

        Console.Write("Due Date: ");
        taskTicket.DueDate = Console.ReadLine();

        using StreamWriter sw = new StreamWriter("Task.csv", append: true);
        sw.WriteLine($"{taskTicket.TicketID},This is a Task,{taskTicket.Summary},{taskTicket.Status},{taskTicket.Priority},{taskTicket.Submitter},{taskTicket.Assigned},{taskTicket.Watching},{taskTicket.ProjectName},{taskTicket.DueDate}");
    }
}