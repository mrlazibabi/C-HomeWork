using Dumpify;
using LINQTongHop.Classes;

string jsonContent = File.ReadAllText("cars.json");
var cars = System.Text.Json.JsonSerializer.Deserialize<List<Car>>(jsonContent);

//1 Lọc các xe hơi có màu sắc là 'Red' hoặc 'Blue', và sắp xếp chúng dựa trên năm sản xuất (tăng dần).
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, năm sản xuất và màu sắc.
var filteredCars = cars
    .Where(car => car.ColorsAvailable == "Red" || car.ColorsAvailable == "Blue")
    .OrderBy(car => car.Year)
    .Select(car => new { car.Make, car.Model, car.Year, car.ColorsAvailable })
    .ToList();
filteredCars.Dump("Filtered Cars (Black or White)");

//2 Lấy danh sách các xe hơi có dung tích xi lanh trên 2.0, và sắp xếp chúng theo công suất giảm dần.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, dung tích xi lanh và công suất.
var powerfulCars = cars
    .Where(c => c.Engine.Displacement > 2.0)
    .OrderByDescending(c => c.Engine.Horsepower)
    .Select(c => new { c.Make, c.Model, c.Engine.Displacement, c.Engine.Horsepower })
    .ToList();
powerfulCars.Dump("Powerful Cars (Displacement > 2.0)");

//3 Lọc các xe hơi có mức tiêu thụ nhiên liệu trong thành phố trên 25 mpg, và sắp xếp chúng theo thứ tự từ xe nhanh nhất đến xe chậm nhất (dựa trên tốc độ tối đa).
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, tốc độ tối đa và mức tiêu thụ nhiên liệu trong thành phố.
var efficentCars = cars
    .Where(c => c.Mileage.City > 25)
    .OrderByDescending(c => c.Performance.TopSpeed)
    .Select(c => new { c.Make, c.Model, c.Performance.TopSpeed, c.Mileage.City})
    .ToList();
efficentCars.Dump("Efficient Cars (City Mileage > 25)");

//4 Lấy danh sách các xe hơi sản xuất sau năm 2010, có trọng lượng không tải dưới 3000 lbs, và sắp xếp chúng theo giá xe từ cao đến thấp.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, năm sản xuất và giá xe.
var lightCars = cars
    .Where(c => c.Year > 2010 && c.Weight.CurbWeight < 3000)
    .OrderByDescending(c => c.Price)
    .Select(c => new { c.Make, c.Model, c.Year, c.Price })
    .ToList();
lightCars.Dump("Light Cars (Year > 2010 and Curb Weight < 3000)");

//5 Lấy danh sách các xe hơi có màu sắc là 'Red', 'Blue' hoặc 'Green', và sắp xếp chúng theo chiều cao từ thấp đến cao.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, chiều cao và màu sắc.
var colorfulCars = cars
    .Where(c => c.ColorsAvailable == "Red" || c.ColorsAvailable == "Blue" || c.ColorsAvailable == "Green")
    .OrderBy(c => c.Dimensions.Height)
    .Select(c => new { c.Make, c.Model, c.Dimensions.Height, c.ColorsAvailable })
    .ToList();
colorfulCars.Dump("Colorful Cars (Red, Blue, Green)");

//6 Lấy danh sách các xe hơi có số dặm bảo hành trên 50000, và sắp xếp chúng theo thời gian bảo hành từ cao đến thấp.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, thời gian bảo hành và số dặm bảo hành.
var wellWarrantiedCars = cars
    .Where(c => c.Warranty.Coverage > 50000)
    .OrderByDescending(c => c.Warranty.Duration)
    .Select(c => new { c.Make, c.Model, c.Warranty.Duration, c.Warranty.Coverage })
    .ToList();
wellWarrantiedCars.Dump("Well Warrantied Cars (Coverage > 50000)");

//7 Lấy danh sách các xe hơi có thời gian bảo hành từ 30 đến 60 tháng, và sắp xếp theo hãng sản xuất từ A đến Z, sau đó theo mẫu xe từ A đến Z.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe và thời gian bảo hành.
var midWarrantiedCars = cars
    .Where(c => c.Warranty.Duration >= 30 && c.Warranty.Duration <= 60)
    .OrderBy(c => c.Make)
    .ThenBy(c => c.Model)
    .Select(c => new { c.Make, c.Model, c.Warranty.Duration })
    .ToList();
midWarrantiedCars.Dump("Mid Warrantied Cars (Duration 30-60 months)");

//8 Lấy danh sách các xe hơi có mức tiêu thụ nhiên liệu trên xa lộ từ 25 mpg trở lên, và sắp xếp theo mức tiêu thụ nhiên liệu trong thành phố từ cao đến thấp.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, mức tiêu thụ nhiên liệu trên xa lộ và mức tiêu thụ nhiên liệu trong thành phố.
var fuelEfficientCars = cars
    .Where(c => c.Mileage.Highway >= 25)
    .OrderByDescending(c => c.Mileage.City)
    .Select(c => new { c.Make, c.Model, c.Mileage.Highway, c.Mileage.City })
    .ToList();
fuelEfficientCars.Dump("Fuel Efficient Cars (Highway Mileage >= 25)");

//9 Lấy danh sách các xe hơi có dung tích xi lanh từ 1.5 trở lên, và sắp xếp theo dung tích xi lanh từ thấp đến cao, sau đó theo công suất từ cao đến thấp.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, dung tích xi lanh và công suất.
var balancedCars = cars
    .Where(c => c.Engine.Displacement >= 1.5)
    .OrderBy(c => c.Engine.Displacement)
    .ThenByDescending(c => c.Engine.Horsepower)
    .Select(c => new { c.Make, c.Model, c.Engine.Displacement, c.Engine.Horsepower })
    .ToList();
balancedCars.Dump("Balanced Cars (Displacement >= 1.5)");

//10 Lấy danh sách các xe hơi có giá xe trên 50000 Rial, và sắp xếp theo giá xe từ cao đến thấp, sau đó theo năm sản xuất từ cao đến thấp.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, năm sản xuất và giá xe
var luxuryCars = cars
    .Where(c => c.Price > 50000)
    .OrderByDescending(c => c.Price)
    .ThenByDescending(c => c.Year)
    .Select(c => new { c.Make, c.Model, c.Year, c.Price })
    .ToList();
luxuryCars.Dump("Luxury Cars (Price > 50000)");

//11 Lấy danh sách các xe hơi có số dặm đi được trên thành phố dưới 30, và sắp xếp theo số dặm đi được trên xa lộ từ cao đến thấp, sau đó theo năm sản xuất từ thấp đến cao.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, số dặm đi được trên xa lộ và năm sản xuất.
var cityEfficientCars = cars
    .Where(c => c.Mileage.City < 30)
    .OrderByDescending(c => c.Mileage.Highway)
    .ThenBy(c => c.Year)
    .Select(c => new { c.Make, c.Model, c.Mileage.Highway, c.Year })
    .ToList();
cityEfficientCars.Dump("City Efficient Cars (City Mileage < 30)");

//12 Lấy danh sách các xe hơi có độ dài cơ sở từ 1700 đến 1900 mm, và sắp xếp theo độ rộng từ cao đến thấp, sau đó theo độ cao từ thấp đến cao.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, độ rộng và độ cao.
var dimensionBalancedCars = cars
    .Where(c => c.Dimensions.Wheelbase >= 1700 && c.Dimensions.Wheelbase <= 1900)
    .OrderByDescending(c => c.Dimensions.Width)
    .ThenBy(c => c.Dimensions.Height)
    .Select(c => new { c.Make, c.Model, c.Dimensions.Width, c.Dimensions.Height })
    .ToList();
dimensionBalancedCars.Dump("Dimension Balanced Cars (Wheelbase 1700-1900 mm)");

//13 Lấy danh sách các xe hơi có công suất từ 200 mã lực trở lên, và sắp xếp theo công suất từ cao đến thấp, sau đó theo dung tích xi lanh từ cao đến thấp.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, công suất và dung tích xi lanh.
var highPerformanceCars = cars
    .Where(c => c.Engine.Horsepower >= 200)
    .OrderByDescending(c => c.Engine.Horsepower)
    .ThenByDescending(c => c.Engine.Displacement)
    .Select(c => new { c.Make, c.Model, c.Engine.Horsepower, c.Engine.Displacement })
    .ToList();
highPerformanceCars.Dump("High Performance Cars (Horsepower >= 200)");

//14 Lấy danh sách các xe hơi có mô tả dài hơn 500 ký tự, và sắp xếp theo độ dài mô tả từ cao đến thấp, sau đó theo năm sản xuất từ cao đến thấp.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, độ dài mô tả và năm sản xuất.
var detailedCars = cars
    .Where(c => c.Description != null && c.Description.Length > 500)
    .OrderByDescending(c => c.Description.Length)
    .ThenByDescending(c => c.Year)
    .Select(c => new { c.Make, c.Model, DescriptionLength = c.Description.Length, c.Year })
    .ToList();
detailedCars.Dump("Detailed Cars (Description Length > 500)");

//15 Lấy danh sách các xe hơi mà ngày sản xuất sau ngày 1 tháng 1 năm 2000, và sắp xếp chúng theo ngày sản xuất từ mới đến cũ.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe và ngày sản xuất.
var modernCars = cars
    .Where(c => DateTime.TryParse(c.ManufactureDate, out DateTime manufactureDate) && manufactureDate > new DateTime(2000, 1, 1))
    .OrderByDescending(c => DateTime.Parse(c.ManufactureDate))
    .Select(c => new { c.Make, c.Model, c.ManufactureDate })
    .ToList();
modernCars.Dump("Modern Cars (Manufacture Date after 01/01/2000)");

//16Lấy danh sách các xe hơi có ngày mua trong khoảng từ năm 2015 đến năm 2020, và sắp xếp theo ngày mua từ cũ đến mới.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe và ngày mua.
var recentPurchaseCars = cars
    .Where(c => DateTime.TryParse(c.PurchaseDate, out DateTime purchaseDate) && purchaseDate.Year >= 2015 && purchaseDate.Year <= 2020)
    .OrderBy(c => DateTime.Parse(c.PurchaseDate))
    .Select(c => new { c.Make, c.Model, c.PurchaseDate })
    .ToList();
recentPurchaseCars.Dump("Recent Purchase Cars (Purchase Date 2015-2020)");

//17 Lấy danh sách các xe hơi có ngày bảo dưỡng gần nhất sau ngày 1 tháng 1 năm 2022, và sắp xếp theo ngày bảo dưỡng từ gần nhất đến xa nhất.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe và ngày bảo dưỡng gần nhất.
var wellMaintainedCars = cars
    .Where(c => DateTime.TryParse(c.LastServiceDate, out DateTime lastServiceDate) && lastServiceDate > new DateTime(2022, 1, 1))
    .OrderByDescending(c => DateTime.Parse(c.LastServiceDate))
    .Select(c => new { c.Make, c.Model, c.LastServiceDate })
    .ToList();
wellMaintainedCars.Dump("Well Maintained Cars (Last Service Date after 01/01/2022)");

//18 Lấy danh sách các xe hơi có mức giá từ 20000 đến 60000 USD, có màu sắc là 'Black' hoặc 'White', và sắp xếp chúng theo năm sản xuất từ mới đến cũ, sau đó theo tên mẫu xe từ A-Z.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, năm sản xuất, màu sắc và giá bán.
var midRangeCars = cars
    .Where(c => c.Price >= 20000 && c.Price <= 60000 && (c.ColorsAvailable == "Black" || c.ColorsAvailable == "White"))
    .OrderByDescending(c => c.Year)
    .ThenBy(c => c.Model)
    .Select(c => new { c.Make, c.Model, c.Year, c.ColorsAvailable, c.Price })
    .ToList();
midRangeCars.Dump("Mid Range Cars (Price 20000-60000 and Color Black or White)");

//19 Lấy danh sách các xe hơi có số dặm bảo hành trên 40000 và thời gian bảo hành dưới 5 năm, và sắp xếp chúng theo thời gian bảo hành từ thấp đến cao, sau đó theo số dặm bảo hành từ cao đến thấp.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, thời gian bảo hành và số dặm bảo hành.
var warrantyEfficientCars = cars
    .Where(c => c.Warranty.Coverage > 40000 && c.Warranty.Duration < 60)
    .OrderBy(c => c.Warranty.Duration)
    .ThenByDescending(c => c.Warranty.Coverage)
    .Select(c => new { c.Make, c.Model, c.Warranty.Duration, c.Warranty.Coverage })
    .ToList();
warrantyEfficientCars.Dump("Warranty Efficient Cars (Coverage > 40000 and Duration < 60 months)");

//20 Lấy danh sách các xe hơi có màu sắc là 'Red' hoặc 'Blue', và có thể chạy được trên 30 dặm một galon nhiên liệu trong thành phố, và sắp xếp chúng theo hiệu suất từ cao đến thấp, sau đó theo tên hãng sản xuất từ A-Z.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, hiệu suất và màu sắc.
var efficientColorfulCars = cars
    .Where(c => (c.ColorsAvailable == "Red" || c.ColorsAvailable == "Blue") && c.Mileage.City > 30)
    .OrderByDescending(c => c.Mileage.City)
    .ThenBy(c => c.Make)
    .Select(c => new { c.Make, c.Model, c.Mileage.City, c.ColorsAvailable })
    .ToList();
efficientColorfulCars.Dump("Efficient Colorful Cars (Color Red or Blue and City Mileage > 30)");

//21 Lấy danh sách các xe hơi sản xuất sau năm 1900, có thể chạy được ít nhất 25 dặm một galon nhiên liệu trên xa lộ, và có giá bán từ 30000 USD trở lên. Sắp xếp các xe theo hiệu suất trên xa lộ từ cao đến thấp, sau đó theo năm sản xuất từ mới đến cũ.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, hiệu suất trên xa lộ và năm sản xuất.
var modernEfficientCars = cars
    .Where(c => c.Year > 1900 && c.Mileage.Highway >= 25 && c.Price >= 30000)
    .OrderByDescending(c => c.Mileage.Highway)
    .ThenByDescending(c => c.Year)
    .Select(c => new { c.Make, c.Model, c.Mileage.Highway, c.Year })
    .ToList();
modernEfficientCars.Dump("Modern Efficient Cars (Year > 1900, Highway Mileage >= 25, Price >= 30000)");

//22 Lấy danh sách các xe hơi có trọng lượng không tải dưới 3000 lbs, có mức tiêu thụ nhiên liệu trong thành phố ít hơn 20 dặm một galon nhiên liệu, và có màu sắc là 'Blue'. Sắp xếp các xe theo mức tiêu thụ nhiên liệu trong thành phố tăng dần, sau đó theo trọng lượng không tải giảm dần.
//Thông tin cần lấy bao gồm hãng sản xuất, mẫu xe, mức tiêu thụ nhiên liệu trong thành phố và trọng lượng không tải.
var lightEfficientSilverCars = cars
    .Where(c => c.Weight.CurbWeight < 3000 && c.Mileage.City < 20 && c.ColorsAvailable == "Blue")
    .OrderBy(c => c.Mileage.City)
    .ThenByDescending(c => c.Weight.CurbWeight)
    .Select(c => new { c.Make, c.Model, c.Mileage.City, c.Weight.CurbWeight })
    .ToList();
lightEfficientSilverCars.Dump("Light Efficient Blue Cars (Curb Weight < 3000, City Mileage < 20, Color Blue)");

