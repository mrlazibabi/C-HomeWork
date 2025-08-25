using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;

namespace ToDoList
{
    public class User
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
    }

    public class Authen
    {
        private readonly string _mockApiUrl = "https://68ac605c7a0bbe92cbba3953.mockapi.io/users";

        public async Task<bool> Register(string email, string password, string role)
        {
            List<User> users = await GetAllUsers();
            if (users.Exists(u => u.Email == email))
            {
                return false;
            }
            string salt = GenerateSalt();
            string hashedPassword = HashPassword(password, salt);
            User newUser = new User { Email = email, HashedPassword = hashedPassword, Salt = salt, Role = role };
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(_mockApiUrl, newUser);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<string> Login(string email, string password)
        {
            List<User> users = await GetAllUsers();
            User user = users.Find(u => u.Email == email);
            if (user != null)
            {
                string hashedPassword = HashPassword(password, user.Salt);
                if (hashedPassword == user.HashedPassword)
                {
                    return user.Role;
                }
            }
            return null;
        }

        public async Task<List<User>> GetAllUsers()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_mockApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
                }
                return new List<User>();
            }
        }

        private string GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        private string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string saltedPassword = password + salt;
                byte[] bytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }

    public class ToDoItem
    {
        public string Id { get; set; }
        public string UserEmail { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class ToDoService
    {
        private readonly string _mockApiUrl = "https://68ac605c7a0bbe92cbba3953.mockapi.io/tasks";

        public async Task AddTask(string userEmail, string title, string description)
        {
            ToDoItem newTask = new ToDoItem { UserEmail = userEmail, Title = title, Description = description, IsCompleted = false };
            using (HttpClient client = new HttpClient())
            {
                await client.PostAsJsonAsync(_mockApiUrl, newTask);
            }
        }

        public async Task<List<ToDoItem>> GetUserTasks(string userEmail)
        {
            List<ToDoItem> allTasks = await GetAllTasks();
            return allTasks.FindAll(t => t.UserEmail == userEmail);
        }

        public async Task<List<ToDoItem>> GetAllTasks()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(_mockApiUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<ToDoItem>>(json) ?? new List<ToDoItem>();
                }
                return new List<ToDoItem>();
            }
        }

        public async Task<bool> EditTask(string id, string userEmail, string title, string description, string role)
        {
            ToDoItem task = await GetTaskById(id);
            if (task == null || (role != "Admin" && task.UserEmail != userEmail))
            {
                return false;
            }
            task.Title = title;
            task.Description = description;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"{_mockApiUrl}/{id}", task);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> MarkCompleted(string id, string userEmail, string role)
        {
            ToDoItem task = await GetTaskById(id);
            if (task == null || (role != "Admin" && task.UserEmail != userEmail))
            {
                return false;
            }
            task.IsCompleted = true;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"{_mockApiUrl}/{id}", task);
                return response.IsSuccessStatusCode;
            }
        }

        public async Task<bool> DeleteTask(string id, string userEmail, string role)
        {
            ToDoItem task = await GetTaskById(id);
            if (task == null || (role != "Admin" && task.UserEmail != userEmail))
            {
                return false;
            }
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync($"{_mockApiUrl}/{id}");
                return response.IsSuccessStatusCode;
            }
        }

        private async Task<ToDoItem> GetTaskById(string id)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync($"{_mockApiUrl}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ToDoItem>(json);
                }
                return null;
            }
        }
    }
}