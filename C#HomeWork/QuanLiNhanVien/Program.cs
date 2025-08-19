using Dumpify;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuanLiNhanVien
{
    public class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string requestUrl = "https://68a45a1bc123272fb9b25b33.mockapi.io/employees";

        public static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("\n=== Quản Lý Nhân Viên ===");
                Console.WriteLine("1. GET (Lấy danh sách nhân viên)");
                Console.WriteLine("2. POST (Thêm nhân viên mới)");
                Console.WriteLine("3. PUT (Cập nhật nhân viên)");
                Console.WriteLine("4. DELETE (Xóa nhân viên)");
                Console.WriteLine("5. Thoát");
                Console.Write("Chọn chức năng (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await GetEmployees();
                        break;
                    case "2":
                        await PostEmployee();
                        break;
                    case "3":
                        await PutEmployee();
                        break;
                    case "4":
                        await DeleteEmployee();
                        break;
                    case "5":
                        Console.WriteLine("Thoát chương trình.");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại!");
                        break;
                }
            }
        }

        //HttpGet
        public static async Task GetEmployees()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(requestUrl);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var employees = JsonSerializer.Deserialize<List<Employee>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                    if (employees == null || employees.Count == 0)
                    {
                        Console.WriteLine("Không có nhân viên nào trong hệ thống.");
                    }
                    else
                    {
                        employees.Dump();
                    }
                }
                else
                {
                    Console.WriteLine($"Lỗi: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }

        //HttpPost
        public static async Task PostEmployee()
        {
            try
            {
                var newEmployee = new Employee
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Salary = 50000,
                    StartDate = DateTime.Now,
                    IsActive = true,
                    Age = 30, // Đổi thành int vì API chấp nhận số nguyên
                    Bonus = 5000
                };
                string json = JsonSerializer.Serialize(newEmployee, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(requestUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Nhân viên đã được thêm thành công!");
                }
                else
                {
                    Console.WriteLine($"Lỗi: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }

        //HttpPut
        public static async Task PutEmployee()
        {
            try
            {
                Console.Write("Nhập ID nhân viên cần cập nhật: ");
                string id = Console.ReadLine();
                if (string.IsNullOrEmpty(id) || !int.TryParse(id, out int employeeId))
                {
                    Console.WriteLine("ID không hợp lệ. Vui lòng nhập số nguyên.");
                    return;
                }

                var updateEmployee = new Employee
                {
                    FirstName = "John",
                    LastName = "Updated",
                    Email = "john.updated@example.com",
                    Salary = 60000,
                    StartDate = DateTime.Now,
                    IsActive = true,
                    Age = 31, // Đổi thành int
                    Bonus = 6000
                };
                string json = JsonSerializer.Serialize(updateEmployee, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                string updateUrl = $"{requestUrl}/{id}";
                HttpResponseMessage response = await client.PutAsync(updateUrl, content);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Nhân viên đã được cập nhật thành công!");
                }
                else
                {
                    Console.WriteLine($"Lỗi: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }

        //HttpDelete
        public static async Task DeleteEmployee()
        {
            try
            {
                Console.Write("Nhập ID nhân viên cần xóa: ");
                string id = Console.ReadLine();
                if (string.IsNullOrEmpty(id) || !int.TryParse(id, out int employeeId))
                {
                    Console.WriteLine("ID không hợp lệ. Vui lòng nhập số nguyên.");
                    return;
                }

                string deleteUrl = $"{requestUrl}/{id}";
                HttpResponseMessage response = await client.DeleteAsync(deleteUrl);
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Nhân viên đã được xóa thành công!");
                }
                else
                {
                    Console.WriteLine($"Lỗi: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }
    }

    public class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsActive { get; set; }
        public int Age { get; set; } 
        public decimal Bonus { get; set; }
    }
}