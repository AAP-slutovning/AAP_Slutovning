using System.Text;

namespace AAP_slutovning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskManager manager = new TaskManager();
            manager.LoadFromFile();
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
                        //Skapa menyval för "Visa alla uppgifter"
                        manager.DisplayAllTasks();
                        break;
                    case "3":
                        // TODO: Markera som klar
                        Console.Write("Ange ID på uppgiften som är klar: ");
                        int.TryParse(Console.ReadLine(), out int taskDone);
                        manager.CompleteTask(taskDone);
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
                        manager.SaveToFile();
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

        //Skapa metod DisplayAllTasks() i TaskManager
        public void DisplayAllTasks()
        {
            Console.Clear();
            Console.WriteLine("--- VISA ALLA UPPGIFTER ---");

            //Hantera tomt fall (inga uppgifter)
            if (tasks.Count < 1)
            {
                Console.WriteLine("Finns inga produkter att visa.");
            }
            else
            {
                // TODO: Implementera logik för att visa alla uppgifter
                foreach (var toDo in tasks)
                {
                    //Formatera utskrift med numrering och status
                    Console.WriteLine(toDo);
                }
            }
            Console.WriteLine("\nTryck på valfri knapp för att återgå till huvudmenyn...");
            Console.ReadKey(true);
            Console.Clear();
        }

        public void CompleteTask(int id)
        {
            // TODO: Implementera logik för att markera som klar
            TodoTask task = tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                Console.WriteLine("Ingen uppgift med ID't hittades");
                return;
            }

            if (task.IsCompleted == true)
            {
                Console.WriteLine($"Uppgift {id} är redan markerad som klar.");
            }
            else
            {
                task.IsCompleted = true;
                Console.WriteLine($"Uppgift {id} är markerad som klar.");
            }
        }

        public void DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
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
        public void SaveToFile()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (var task in tasks)
                {
                    sb.AppendLine($"{task.Id}|{task.Title}|{task.IsCompleted}");
                }
                File.WriteAllText("tasks.txt", sb.ToString());
                Console.WriteLine("uppgifter sparade till fil");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid sparning: {ex.Message}");
            }





        }

        public void LoadFromFile()
        {
            try
            {
                tasks.Clear(); 

                string content = File.ReadAllText("tasks.txt");
                string[] lines = content.Split(Environment.NewLine);

                foreach (var line in lines)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    string[] parts = line.Split('|');
                    if (parts.Length == 3 &&
                        int.TryParse(parts[0], out int id) &&
                        bool.TryParse(parts[2], out bool isCompleted))
                    {
                        TodoTask task = new TodoTask(id, parts[1]) { IsCompleted = isCompleted };
                        tasks.Add(task);
                        nextId = Math.Max(nextId, id + 1);
                    }
                }

                Console.WriteLine("Uppgifter laddade från fil.");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Ingen sparad fil hittades. Börjar med tom lista.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fel vid inläsning: {ex.Message}");
            }
        }

    } }


    
