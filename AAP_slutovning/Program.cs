namespace AAP_slutovning
{
    internal class Program
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
                        Console.WriteLine("Skriv in titeln för ny uppgift:");
                        string titleInput = Console.ReadLine();
                        manager.AddTask(titleInput);
                        break;
                    case "2":
                        // TODO: Visa alla uppgifter
                        break;
                    case "3":
                        // TODO: Markera som klar
                        break;
                    case "4":
                        // TODO: Ta bort uppgift
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
        }
    }
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
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Uppgiftens titel kan inte vara tom!");
                return;
            }

            TodoTask newTask = new TodoTask(nextId, title);
            tasks.Add(newTask);

            Console.WriteLine($"{title} har lagts till med ID:{nextId}");

            nextId++;
        }

        public void DisplayAllTasks()
        {
            // TODO: Implementera logik för att visa alla uppgifter
        }

        public void CompleteTask(int id)
        {
            // TODO: Implementera logik för att markera som klar
        }

        public void DeleteTask(int id)
        {
            // TODO: Implementera logik för att ta bort uppgift
        }
    }

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
}