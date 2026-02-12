namespace AAP_slutovning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}



///////////////////////////////////////

public class TodoTask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }

    public TodoTask(int id, string title)
    {
        Id = id;
        Title = title;
        IsCompleted = false;
    }

    public override string ToString()
    {
        string status = IsCompleted ? "[X]" : "[ ]";
        return $"{status} {Id}. {Title}";
    }
}

////////////////////////////////////


public class TaskManager
{
    private List<TodoTask> tasks;
    private int nextId;

    public TaskManager()
    {
        tasks = new List<TodoTask>();
        nextId = 1;
    }

    public void AddTask(string title)
    {
    //TODO: Implementera logik för att lägga till uppgift
    }

    public void DisplayAllTasks()
    {
    //TODO: Implementera logik för att visa alla uppgifter
    }

    public void CompleteTask(int id)
    {
    //TODO: Implementera logik för att markera som klar
    }
    
    public void DeleteTask(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task != null)
        {
            Console.WriteLine($"Ogiltigt id");
            return;
        }
        else
        {
            tasks.Remove(task);
            Console.WriteLine($"Uppgift {id} har tagits bort.");
        }
    }

    //////////////////////////////////////


    class Program
    {
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();
            bool running = true;

            while (running)
            {
                DisplayMenu();
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                    //TODO: Lägg till uppgift
                        break;
                    case "2":
                    //TODO: Visa alla uppgifter
                        break;
                    case "3":
                    //TODO: Markera som klar
                        break;
                    case "4": 
                         Console.WriteLine("Ange id för att ta bort uppgift:");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            manager.DeleteTask(deleteId);
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt id!");
                        }
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Hej då!");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val!");
                        break;
                }
            }
        }

        static void DisplayMenu()
        {
            Console.WriteLine("\n=== TO-DO LIST ===");
            Console.WriteLine("1. Lägg till uppgift");
            Console.WriteLine("2. Visa alla uppgifter");
            Console.WriteLine("3. Markera uppgift som klar");
            Console.WriteLine("4. Ta bort uppgift");
            Console.WriteLine("5. Avsluta");
            Console.Write("Välj ett alternativ: ");
        }
    } }


