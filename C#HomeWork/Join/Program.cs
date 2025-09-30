using Newtonsoft.Json;
using Dumpify;

Console.OutputEncoding = System.Text.Encoding.UTF8;
// Đường dẫn đến các file JSON
string customersFile = @"Data\MOCK_DATA_Customers.json";
string orderDetailsFile = @"Data\MOCK_DATA_OrderDetails.json";
string ordersFile = @"Data\MOCK_DATA_Orders.json";
string productsFile = @"Data\MOCK_DATA_Products.json";

// Đọc nội dung từ các file JSON
List<Customer> customers = ReadJsonFile<List<Customer>>(customersFile);
List<OrderDetail> orderDetails = ReadJsonFile<List<OrderDetail>>(orderDetailsFile);
List<Order> orders = ReadJsonFile<List<Order>>(ordersFile);
List<Product> products = ReadJsonFile<List<Product>>(productsFile);

// Hiển thị số lượng dữ liệu đã đọc được từ mỗi file
Console.WriteLine($"Số lượng khách hàng: {customers.Count}");
Console.WriteLine($"Số lượng chi tiết đơn hàng: {orderDetails.Count}");
Console.WriteLine($"Số lượng đơn hàng: {orders.Count}");
Console.WriteLine($"Số lượng sản phẩm: {products.Count}");

T ReadJsonFile<T>(string filePath)
{
    using (StreamReader file = File.OpenText(filePath))
    {
        JsonSerializer serializer = new JsonSerializer();
        return (T)serializer.Deserialize(file, typeof(T));
    }
}

//1 Tạo một danh sách gồm tên đầy đủ của khách hàng và tổng số đơn hàng mà mỗi khách hàng đã đặt.
//Sắp xếp giảm dần theo tổng số đơn hàng. (Giải bằng 2 cách: Join và GroupJoin)
var q1 = customers
    .GroupJoin(orders,
        c => c.Id,
        o => o.CustomerId,
        (c, totalOrders) => new
        {
            CustomerName = c.FullName,
            TotalOrders = totalOrders.Count()
        })
    .OrderByDescending(x => x.TotalOrders);
q1.Dump("Câu 1 - ");

//2 Lấy danh sách tên sản phẩm và tổng số lượng sản phẩm đã được đặt trong các đơn hàng. sảy ra trong năm 2019 & 2020
var q2 = orderDetails
    .Join(orders.Where(o => o.OrderDate.Year == 2019 || o.OrderDate.Year == 2020),
        od => od.OrderId,
        o => o.Id,
        (od, o) => new { od.ProductId, od.Quantity })
    .GroupBy(x => x.ProductId)
    .Join(products,
        g => g.Key,
        p => p.Id,
        (g, p) => new
        {
            ProductName = p.Name,
            TotalQuantity = g.Sum(x => x.Quantity)
        });
q2.Dump("Câu 2 - ");

//3 Tạo danh sách gồm tên Nhà sản xuất và tên sản phẩm rẻ nhất của từng Nhà sản xuất.
var q3 = products
    .GroupBy(p => p.Manufacturer)
    .Select(g => new
    {
        Manufacturer = g.Key,
        CheapestProduct = g.OrderBy(p => p.Price).First().Name
    });
q3.Dump("Câu 3 - ");

//4 Đếm số lượng khách hàng theo từng loại thành viên và sắp xếp theo thứ tự giảm dần của số lượng.
var q4 = customers
    .GroupBy(c => c.MembershipStatus)
    .Select(g => new
    {
        MembershipStatus = g.Key,
        CustomerCount = g.Count()
    })
    .OrderByDescending(x => x.CustomerCount);
q4.Dump("Câu 4 - ");

//5 Liệt kê tất cả khách hàng đã đặt ít nhất một đơn hàng, và số lượng đơn hàng mà mỗi khách hàng đã đặt.
//Sắp xếp giảm dần theo đơn hàng giá trị nhất của mỗi khách hàng.
var q5 = customers
    .Join(orders,
        c => c.Id,
        o => o.CustomerId,
        (c, o) => new { c.FullName, o.Id })
    .GroupBy(x => x.FullName)
    .Select(g => new
    {
        CustomerName = g.Key,
        TotalOrders = g.Count()
    })
    .OrderByDescending(x => x.TotalOrders);
q5.Dump("Câu 5 - ");

//6 Tạo một danh sách gồm tên đầy đủ của khách hàng, tổng giá trị đơn hàng của từng khách hàng và sắp xếp giảm dần theo tổng giá trị.
var q6 = customers
    .GroupJoin(orders, c => c.Id, o => o.CustomerId, (c, os) => new
    {
        Customer = c.FullName,
        TotalValue = os
            .Join(orderDetails, o => o.Id, od => od.OrderId, (o, od) => od)
            .Join(products, od => od.ProductId, p => p.Id, (od, p) => od.Quantity * p.Price).Sum()
    })
    .OrderByDescending(x => x.TotalValue);
q6.Dump("Câu 6 - ");

//7 Đếm số lượng sản phẩm theo từng loại danh mục và sắp xếp theo thứ tự tăng dần của số lượng.
var q7 = products
    .SelectMany(p => p.Category, (p, category) => new { p.Id, Category = category })
    .GroupBy(x => x.Category)
    .Select(g => new
    {
        Category = g.Key,
        ProductCount = g.Count()
    })
    .OrderBy(x => x.ProductCount);
q7.Dump("Câu 7 - ");

//8 Liệt kê các đơn hàng có giá trị cao nhất của từng năm kèm với tên khách hàng đã đặt đơn hàng này.
var q8 = orders
    .GroupBy(o => o.OrderDate.Year)
    .Select(g => g
        .Select(o => new
        {
            Year = g.Key,
            OrderId = o.Id,
            Customer = customers.First(c => c.Id == o.CustomerId).FullName,
            TotalValue = orderDetails
                .Where(od => od.OrderId == o.Id)
                .Join(products, od => od.ProductId, p => p.Id, (od, p) => od.Quantity * p.Price).Sum()
        })
        .OrderByDescending(x => x.TotalValue).FirstOrDefault()
    );
q8.Dump("Câu 8 - ");

//9 Thống kê sản phẩm và tổng số lượng sản phẩm đã bán của từng nhà sản xuất, doanh thu của sản phẩm, sắp xếp theo doanh thu của sản phẩm tăng dần.
var q9 = products
    .GroupJoin(orderDetails, p => p.Id, od => od.ProductId, (p, ods) => new
    {
        p.Manufacturer,
        ProductName = p.Name,
        TotalQuantitySold = ods.Sum(od => od.Quantity),
        TotalRevenue = ods.Sum(od => od.Quantity * p.Price)
    })
    .OrderBy(x => x.TotalRevenue);
q9.Dump("Câu 9 - ");

//10 Tạo danh sách các sản phẩm có giá cao nhất trong từng danh mục và sắp xếp theo danh mục theo thứ tự bảng chữ cái.
var q10 = products
    .SelectMany(p => p.Category, (p, category) => new { p, Category = category })
    .GroupBy(x => x.Category)
    .Select(g => g.OrderByDescending(x => x.p.Price).First())
    .Select(x => new
    {
        x.Category,
        ProductName = x.p.Name,
        x.p.Price
    })
    .OrderBy(x => x.Category);
q10.Dump("Câu 10 - ");

//11 Liệt kê các khách hàng đã mua sản phẩm từ năm 2020 trở đi, và tính tổng số tiền mỗi khách hàng đã chi tiêu. Chỉ lấy những khách hàng đã tiêu trên 250$.
//Sắp xếp danh sách theo tổng số tiền giảm dần.
var q11 = customers
    .GroupJoin(orders.Where(o => o.OrderDate.Year >= 2020), c => c.Id, o => o.CustomerId, (c, os) => new
    {
        CustomerName = c.FullName,
        TotalSpent = os
            .Join(orderDetails, o => o.Id, od => od.OrderId, (o, od) => od)
            .Join(products, od => od.ProductId, p => p.Id, (od, p) => od.Quantity * p.Price).Sum()
    })
    .Where(x => x.TotalSpent > 250)
    .OrderByDescending(x => x.TotalSpent);
q11.Dump("Câu 11 -");

//12 Tính tổng số lượng sản phẩm và giá trị được đặt mỗi năm của từng sản phẩm.
var q12 = orders
    .Join(orderDetails, o => o.Id, od => od.OrderId, (o, od) => new { o.OrderDate, od })
    .Join(products, x => x.od.ProductId, p => p.Id, (x, p) => new
    {
        x.OrderDate.Year,
        Product = p.Name,
        x.od.Quantity,
        Value = x.od.Quantity * p.Price
    })
    .GroupBy(x => new { x.Year, x.Product })
    .Select(g => new
    {
        g.Key.Year,
        g.Key.Product,
        TotalQuantity = g.Sum(x => x.Quantity),
        TotalValue = g.Sum(x => x.Value)
    });
q12.Dump("Câu 12 - ");

public class Customer
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string MembershipStatus { get; set; }
    public DateTime LastPurchaseDate { get; set; }
    public int LoyaltyPoints { get; set; }
}


public class Order
{
    public int Id { get; set; }
    public DateTime OrderDate { get; set; }
    public int CustomerId { get; set; }
    public Shipping Shipping { get; set; }
}

public class Shipping
{
    public string Address { get; set; }
    public DateTime Date { get; set; }
}

public class OrderDetail
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}


public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string Manufacturer { get; set; }
    public DateTime CreateDate { get; set; }
    public List<string> Category { get; set; }
}
