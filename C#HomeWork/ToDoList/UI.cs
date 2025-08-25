using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoList
{
    public class UI
    {
        private Authen authen;
        private ToDoService toDoService;
        private bool isRunning = true;
        private string currentUserEmail = null;
        private string currentUserRole = null;

        public UI(Authen authen, ToDoService toDoService)
        {
            this.authen = authen;
            this.toDoService = toDoService;
        }

        public async Task Run()
        {
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the To-Do List Management System!");
                Console.WriteLine("1. Register (as User)");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. Exit");
                Console.Write("Please select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await RegisterUser();
                        break;
                    case "2":
                        await LoginUser();
                        break;
                    case "3":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
                if (isRunning)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private async Task RegisterUser()
        {
            Console.Write("Enter email (username): ");
            string regEmail = Console.ReadLine();
            Console.Write("Enter password: ");
            string regPassword = Console.ReadLine();
            if (await authen.Register(regEmail, regPassword, "User"))
            {
                Console.WriteLine("Registration successful!");
            }
            else
            {
                Console.WriteLine("Email already exists.");
            }
        }

        private async Task LoginUser()
        {
            Console.Write("Enter email (username): ");
            string loginEmail = Console.ReadLine();
            Console.Write("Enter password: ");
            string loginPassword = Console.ReadLine();
            string role = await authen.Login(loginEmail, loginPassword);
            if (role != null)
            {
                Console.WriteLine("Login successful! Authentication completed.");
                currentUserEmail = loginEmail;
                currentUserRole = role;
                if (currentUserRole == "Admin")
                {
                    await AdminMenu();
                }
                else
                {
                    await UserMenu();
                }
            }
            else
            {
                Console.WriteLine("Invalid email or password.");
            }
        }

        private async Task UserMenu()
        {
            bool inMenu = true;
            while (inMenu)
            {
                Console.Clear();
                Console.WriteLine($"User Menu for {currentUserEmail}");
                Console.WriteLine("1. Add new task");
                Console.WriteLine("2. View my tasks");
                Console.WriteLine("3. Edit task");
                Console.WriteLine("4. Mark task as completed");
                Console.WriteLine("5. Delete task");
                Console.WriteLine("6. Logout");
                Console.Write("Select option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await AddTask();
                        break;
                    case "2":
                        await ViewMyTasks();
                        break;
                    case "3":
                        await EditTask();
                        break;
                    case "4":
                        await MarkCompleted();
                        break;
                    case "5":
                        await DeleteTask();
                        break;
                    case "6":
                        inMenu = false;
                        currentUserEmail = null;
                        currentUserRole = null;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private async Task AdminMenu()
        {
            bool inMenu = true;
            while (inMenu)
            {
                Console.Clear();
                Console.WriteLine($"Admin Menu for {currentUserEmail}");
                Console.WriteLine("1. View all tasks");
                Console.WriteLine("2. Edit any task");
                Console.WriteLine("3. Delete any task");
                Console.WriteLine("4. View all users");
                Console.WriteLine("5. Logout");
                Console.Write("Select option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await ViewAllTasks();
                        break;
                    case "2":
                        await EditAnyTask();
                        break;
                    case "3":
                        await DeleteAnyTask();
                        break;
                    case "4":
                        await ViewAllUsers();
                        break;
                    case "5":
                        inMenu = false;
                        currentUserEmail = null;
                        currentUserRole = null;
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        private async Task AddTask()
        {
            Console.Write("Enter task title: ");
            string title = Console.ReadLine();
            Console.Write("Enter task description: ");
            string desc = Console.ReadLine();
            await toDoService.AddTask(currentUserEmail, title, desc);
            Console.WriteLine("Task added successfully!");
        }

        private async Task ViewMyTasks()
        {
            List<ToDoItem> tasks = await toDoService.GetUserTasks(currentUserEmail);
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
            }
            else
            {
                foreach (var task in tasks)
                {
                    Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Desc: {task.Description}, Completed: {task.IsCompleted}");
                }
            }
        }

        private async Task EditTask()
        {
            Console.Write("Enter task ID to edit: ");
            string id = Console.ReadLine();
            Console.Write("New title: ");
            string title = Console.ReadLine();
            Console.Write("New description: ");
            string desc = Console.ReadLine();
            if (await toDoService.EditTask(id, currentUserEmail, title, desc, currentUserRole))
            {
                Console.WriteLine("Task edited successfully!");
            }
            else
            {
                Console.WriteLine("Task not found or access denied.");
            }
        }

        private async Task MarkCompleted()
        {
            Console.Write("Enter task ID to mark completed: ");
            string id = Console.ReadLine();
            if (await toDoService.MarkCompleted(id, currentUserEmail, currentUserRole))
            {
                Console.WriteLine("Task marked as completed!");
            }
            else
            {
                Console.WriteLine("Task not found or access denied.");
            }
        }

        private async Task DeleteTask()
        {
            Console.Write("Enter task ID to delete: ");
            string id = Console.ReadLine();
            if (await toDoService.DeleteTask(id, currentUserEmail, currentUserRole))
            {
                Console.WriteLine("Task deleted successfully!");
            }
            else
            {
                Console.WriteLine("Task not found or access denied.");
            }
        }

        private async Task ViewAllTasks()
        {
            List<ToDoItem> tasks = await toDoService.GetAllTasks();
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found.");
            }
            else
            {
                foreach (var task in tasks)
                {
                    Console.WriteLine($"ID: {task.Id}, User: {task.UserEmail}, Title: {task.Title}, Desc: {task.Description}, Completed: {task.IsCompleted}");
                }
            }
        }

        private async Task EditAnyTask()
        {
            Console.Write("Enter task ID to edit: ");
            string id = Console.ReadLine();
            Console.Write("New title: ");
            string title = Console.ReadLine();
            Console.Write("New description: ");
            string desc = Console.ReadLine();
            if (await toDoService.EditTask(id, null, title, desc, "Admin"))
            {
                Console.WriteLine("Task edited successfully!");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        private async Task DeleteAnyTask()
        {
            Console.Write("Enter task ID to delete: ");
            string id = Console.ReadLine();
            if (await toDoService.DeleteTask(id, null, "Admin"))
            {
                Console.WriteLine("Task deleted successfully!");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        private async Task ViewAllUsers()
        {
            List<User> users = await authen.GetAllUsers();
            if (users.Count == 0)
            {
                Console.WriteLine("No users found.");
            }
            else
            {
                foreach (var user in users)
                {
                    Console.WriteLine($"ID: {user.Id}, Email: {user.Email}, Role: {user.Role}");
                }
            }
        }
    }
}