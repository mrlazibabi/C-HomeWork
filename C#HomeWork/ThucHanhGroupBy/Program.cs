using Dumpify;
using ThucHanhGroupBy.Classes;

Console.OutputEncoding = System.Text.Encoding.UTF8;
var jsonContent = File.ReadAllText("users.json");
var users = System.Text.Json.JsonSerializer.Deserialize<List<User>>(jsonContent);

//1 Nhóm theo UserType, hiển thị số người, tuổi lớn nhất, nhỏ nhất, trung bình.
var groupedUserType = users
    .GroupBy(users => users.UserType)
    .Select(g => new
    {
        UserType = g.Key,
        Count = g.Count(),
        HighestAge = g.Max(u => u.Age),
        LowestAge = g.Min(u => u.Age),
        AverageAge = g.Average(u => u.Age)
    });
groupedUserType.Dump("Grouped by UserType");

//2 Nhóm theo Gender, hiển thị số người, tuổi lớn nhất, nhỏ nhất, trung bình, sắp xếp theo tên giới tính (tăng dần).
var groupedGender = users
    .GroupBy(users => users.Gender)
    .Select(g => new
    {
        groupedGender = g.Key,
        Count = g.Count(),
        HighestAge = g.Max(u => u.Age),
        LowestAge = g.Min(u => u.Age),
        AverageAge = g.Average(u => u.Age)
    })
    .OrderBy(g => g.groupedGender);
groupedGender.Dump("Grouped by Gender");

//3 Nhóm theo Age, đếm số người trong từng độ tuổi, sắp xếp theo số lượng người (tăng dần).
var groupedAge = users
    .GroupBy(users => users.Age)
    .Select(g => new
    {
        Age = g.Key,
        Count = g.Count()
    })
    .OrderBy(g => g.Count);
groupedAge.Dump("Grouped by Age");

//4 Nhóm theo City, đếm số người trong từng thành phố, sắp xếp theo tên thành phố (tăng dần).
var groupedCity = users
    .GroupBy(users => users.City)
    .Select(g => new
    {
        City = g.Key,
        Count = g.Count()
    })
    .OrderBy(g => g.City);
groupedCity.Dump("Grouped by City");

//5 Nhóm theo City, chỉ hiển thị thành phố có từ 3 người trở lên, sắp xếp theo tên thành phố (tăng dần).
var groupedCityWithMin3Users = users
    .GroupBy(users => users.City)
    .Select(g => new
    {
        City = g.Key,
        Count = g.Count()
    })
    .Where(g => g.Count >= 3)
    .OrderBy(g => g.City);
groupedCityWithMin3Users.Dump("Grouped by City with at least 3 users");

//6 Nhóm theo Age, chỉ hiển thị độ tuổi có ít nhất 2 người (không cần sắp xếp).
var groupedAgeWithMin2Users = users
    .GroupBy(users => users.Age)
    .Select(g => new
    {
        Age = g.Key,
        Count = g.Count()
    })
    .Where(g => g.Count >= 2);
groupedAgeWithMin2Users.Dump("Grouped by Age with at least 2 users");

