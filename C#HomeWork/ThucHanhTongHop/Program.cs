using Dumpify;
using ThucHanhTongHop.Classes;

Console.OutputEncoding = System.Text.Encoding.UTF8;
var jsonContent = File.ReadAllText("orders-with-review.json");
var orders = System.Text.Json.JsonSerializer.Deserialize<List<Order>>(jsonContent);

//1 Lọc các đơn hàng trong tháng 7/2023, sắp xếp theo ngày đặt hàng tăng dần, nếu trùng ngày thì sắp xếp theo số lượng sản phẩm giảm dần.
var filteredOrders = orders?
    .Where(o => DateTime.Parse(o.OrderDate).Month == 7 && DateTime.Parse(o.OrderDate).Year == 2023)
    .OrderBy(o => DateTime.Parse(o.OrderDate))
    .ThenByDescending(o => o.Customer?.Items?.Count ?? 0);
filteredOrders.Dump("1. Đơn hàng trong tháng 7/2023, sắp xếp theo ngày đặt hàng tăng dần, nếu trùng ngày thì sắp xếp theo số lượng sản phẩm giảm dần");

//2 Lọc các đơn hàng trong tháng 7/2023, chỉ giữ lại đơn hàng có tổng giá trị > 5000, sau đó sắp xếp theo số lượng sản phẩm giảm dần.
var filteredOrders2 = orders?
    .Where(o => DateTime.Parse(o.OrderDate).Month == 7 && DateTime.Parse(o.OrderDate).Year == 2023)
    .Where(o => (o.Customer?.Items?.Sum(i => i.UnitPrice * i.Quantity) ?? 0) > 5000)
    .OrderByDescending(o => o.Customer?.Items?.Count ?? 0);
filteredOrders2.Dump("2. Đơn hàng trong tháng 7/2023, chỉ giữ lại đơn hàng có tổng giá trị > 5000, sau đó sắp xếp theo số lượng sản phẩm giảm dần");

//3 Lọc các đơn hàng trong năm 2023, chỉ giữ lại đơn có tổng số lượng sản phẩm ≥ 4, rồi sắp xếp theo tổng giá trị giảm dần.
var filteredOrders3 = orders?
    .Where(o => DateTime.Parse(o.OrderDate).Year == 2023)
    .Where(o => (o.Customer?.Items?.Sum(i => i.Quantity) ?? 0) >= 4)
    .OrderByDescending(o => o.Customer?.Items?.Sum(i => i.UnitPrice * i.Quantity) ?? 0);
filteredOrders3.Dump("3. Đơn hàng trong năm 2023, chỉ giữ lại đơn có tổng số lượng sản phẩm ≥ 4, rồi sắp xếp theo tổng giá trị giảm dần");

//4 Lọc các đơn hàng trong năm 2023, lấy các thông tin: số đơn hàng, tên khách hàng, tổng số sản phẩm; sắp xếp theo số sản phẩm giảm dần.
var filteredOrders4 = orders?
    .Where(o => DateTime.Parse(o.OrderDate).Year == 2023)
    .Select(o => new
    {
        o.OrderNumber,
        CustomerName = $"{o.Customer?.FirstName} {o.Customer?.LastName}",
        TotalProducts = o.Customer?.Items?.Sum(i => i.Quantity) ?? 0
    })
    .OrderByDescending(o => o.TotalProducts);
filteredOrders4.Dump("4. Đơn hàng trong năm 2023, lấy các thông tin: số đơn hàng, tên khách hàng, tổng số sản phẩm; sắp xếp theo số sản phẩm giảm dần");

//5 Lọc các đơn hàng trong năm 2023, lấy: số đơn hàng, tên khách hàng, tổng giá trị, và thành phố giao hàng; sắp xếp theo tổng giá trị giảm dần.
var filteredOrders5 = orders?
    .Where(o => DateTime.Parse(o.OrderDate).Year == 2023)
    .Select(o => new
    {
        o.OrderNumber,
        CustomerName = $"{o.Customer?.FirstName} {o.Customer?.LastName}",
        TotalValue = o.Customer?.Items?.Sum(i => i.UnitPrice * i.Quantity) ?? 0,
        City = o.Customer?.Address?.City
    })
    .OrderByDescending(o => o.TotalValue);
filteredOrders5.Dump("5. Đơn hàng trong năm 2023, lấy: số đơn hàng, tên khách hàng, tổng giá trị, và thành phố giao hàng; sắp xếp theo tổng giá trị giảm dần");

//6 Lọc đơn hàng trong tháng 7/2023, lấy: số đơn hàng, tên khách hàng, tổng số lượng sản phẩm, tổng giá trị; sắp xếp theo tổng giá trị giảm dần.
var filteredOrders6 = orders?
    .Where(o => DateTime.Parse(o.OrderDate).Month == 7 && DateTime.Parse(o.OrderDate).Year == 2023)
    .Select(o => new
    {
        o.OrderNumber,
        CustomerName = $"{o.Customer?.FirstName} {o.Customer?.LastName}",
        TotalQuantity = o.Customer?.Items?.Sum(i => i.Quantity) ?? 0,
        TotalValue = o.Customer?.Items?.Sum(i => i.UnitPrice * i.Quantity) ?? 0
    })
    .OrderByDescending(o => o.TotalValue);
filteredOrders6.Dump("6. Đơn hàng trong tháng 7/2023, lấy: số đơn hàng, tên khách hàng, tổng số lượng sản phẩm, tổng giá trị; sắp xếp theo tổng giá trị giảm dần");

//7 Lọc đơn hàng trong năm 2023, chỉ giữ đơn hàng có tổng giá trị > 10000, lấy: số đơn hàng, tên khách hàng, tổng số lượng, tổng giá trị; sắp xếp theo tổng số lượng giảm dần.
var filteredOrders7 = orders?
    .Where(o => DateTime.Parse(o.OrderDate).Year == 2023)
    .Where(o => (o.Customer?.Items?.Sum(i => i.UnitPrice * i.Quantity) ?? 0) > 10000)
    .Select(o => new
    {
        o.OrderNumber,
        CustomerName = $"{o.Customer?.FirstName} {o.Customer?.LastName}",
        TotalQuantity = o.Customer?.Items?.Sum(i => i.Quantity) ?? 0,
        TotalValue = o.Customer?.Items?.Sum(i => i.UnitPrice * i.Quantity) ?? 0
    })
    .OrderByDescending(o => o.TotalQuantity);
filteredOrders7.Dump("7. Đơn hàng trong năm 2023, chỉ giữ đơn hàng có tổng giá trị > 10000, lấy: số đơn hàng, tên khách hàng, tổng số lượng, tổng giá trị; sắp xếp theo tổng số lượng giảm dần");

//8 Lọc đơn hàng trong năm 2023, chỉ lấy đơn hàng có giá trị từ 5000 đến 10000, lấy: số đơn hàng, tên khách hàng, tổng giá trị; sắp xếp theo số đơn hàng giảm dần.
var filteredOrders8 = orders?
    .Where(o => DateTime.Parse(o.OrderDate).Year == 2023)
    .Where(o => (o.Customer?.Items?.Sum(i => i.UnitPrice * i.Quantity) ?? 0) is >= 5000 and <= 10000)
    //.Where(o => 
    //{
    //    var totalValue = o.Customer?.Items?.Sum(i => i.UnitPrice * i.Quantity) ?? 0;
    //    return totalValue >= 5000 && totalValue <= 10000;
    //})
    .Select(o => new
    {
        o.OrderNumber,
        CustomerName = $"{o.Customer?.FirstName} {o.Customer?.LastName}",
        TotalValue = o.Customer?.Items?.Sum(i => i.UnitPrice * i.Quantity) ?? 0
    })
    .OrderByDescending(o => o.OrderNumber);
filteredOrders8.Dump("8. Đơn hàng trong năm 2023, chỉ lấy đơn hàng có giá trị từ 5000 đến 10000, lấy: số đơn hàng, tên khách hàng, tổng giá trị; sắp xếp theo số đơn hàng giảm dần");

//9 Lọc đơn hàng trong năm 2023 và có ngày đặt rơi vào Thứ Hai, lấy: số đơn hàng, tên khách hàng, ngày đặt, tổng giá trị; sắp xếp theo ngày đặt mới đến cũ.
var filteredOrders9 = orders?
    .Where(o => DateTime.Parse(o.OrderDate).Year == 2023)
    .Where(o => DateTime.Parse(o.OrderDate).DayOfWeek == DayOfWeek.Monday)
    .Select(o => new
    {
        o.OrderNumber,
        CustomerName = $"{o.Customer?.FirstName} {o.Customer?.LastName}",
        o.OrderDate,
        TotalValue = o.Customer?.Items?.Sum(i => i.UnitPrice * i.Quantity) ?? 0
    })
    .OrderByDescending(o => DateTime.Parse(o.OrderDate));
filteredOrders9.Dump("9. Đơn hàng trong năm 2023 và có ngày đặt rơi vào Thứ Hai, lấy: số đơn hàng, tên khách hàng, ngày đặt, tổng giá trị; sắp xếp theo ngày đặt mới đến cũ");

//10 Lọc đơn hàng trong năm 2023, chỉ lấy đơn có tổng số lượng sản phẩm > 3, lấy: số đơn hàng, tên khách hàng, ngày đặt hàng, tổng số lượng sản phẩm; sắp xếp theo ngày đặt mới đến cũ.
var filteredOrders10 = orders?
    .Where(o => DateTime.Parse(o.OrderDate).Year == 2023)
    .Where(o => (o.Customer?.Items?.Sum(i => i.Quantity) ?? 0) > 3)
    .Select(o => new
    {
        o.OrderNumber,
        CustomerName = $"{o.Customer?.FirstName} {o.Customer?.LastName}",
        o.OrderDate,
        TotalQuantity = o.Customer?.Items?.Sum(i => i.Quantity) ?? 0
    })
    .OrderByDescending(o => DateTime.Parse(o.OrderDate));
filteredOrders10.Dump("10. Đơn hàng trong năm 2023, chỉ lấy đơn có tổng số lượng sản phẩm > 3, lấy: số đơn hàng, tên khách hàng, ngày đặt hàng, tổng số lượng sản phẩm; sắp xếp theo ngày đặt mới đến cũ");
