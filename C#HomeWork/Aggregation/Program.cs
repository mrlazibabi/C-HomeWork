using Dumpify;
using Aggregation.Classes;

Console.OutputEncoding = System.Text.Encoding.UTF8;
string jsonContent = File.ReadAllText("orders.json");
var orders = System.Text.Json.JsonSerializer.Deserialize<List<Order>>(jsonContent);

//1 Tính tổng giá của tất cả sản phẩm trong từng đơn hàng. In ra mã đơn hàng, tên khách hàng, và tổng tiền đơn hàng.
var totalPrices = orders.Select(order => new
{
    order.OrderId,
    order.NameOfCustomer,
    TotalPrice = order.Products.Sum(item => item.Price)
});
totalPrices.Dump("Tổng giá của tất cả sản phẩm trong từng đơn hàng");

//2 Tìm sản phẩm rẻ nhất trong từng đơn hàng. In ra mã đơn hàng, tên khách hàng, và tên của sản phẩm có giá thấp nhất.
var cheapestProducts = orders.Select(order => new
{
    order.OrderId,
    order.NameOfCustomer,
    CheapestProduct = (order.Products?.OrderBy(item => item.Price))?.FirstOrDefault()?.Name ?? "No products"
});
cheapestProducts.Dump("Sản phẩm rẻ nhất trong từng đơn hàng");

//3 Tìm sản phẩm đắt nhất trong từng đơn hàng. In ra mã đơn hàng, tên khách hàng, và tên của sản phẩm có giá cao nhất.
var mostExpensiveProducts = orders.Select(order => new
{
    order.OrderId,
    order.NameOfCustomer,
    MostExpensiveProducts = (order.Products?.OrderByDescending(item => item.Price))?.FirstOrDefault()?.Name ?? "No products"
});
mostExpensiveProducts.Dump("Sản phẩm đắt nhất trong từng đơn hàng");

//5 Tìm giá nhỏ nhất trong từng đơn hàng (chỉ in ra số tiền nhỏ nhất, không cần tên sản phẩm). In ra mã đơn hàng, tên khách hàng, và giá thấp nhất.
var lowestPrices = orders.Select(order => new
{
    order.OrderId,
    order.NameOfCustomer,
    LowestPrice = (order.Products?.OrderBy(item => item.Price))?.FirstOrDefault()?.Price ?? 0
});
lowestPrices.Dump("Giá nhỏ nhất trong từng đơn hàng");

//6 Liệt kê tên các sản phẩm trong từng đơn hàng, nối bằng dấu phẩy. In ra mã đơn hàng, tên khách hàng, và danh sách tên sản phẩm.
var productNames = orders.Select(order => new
{
    order.OrderId,
    order.NameOfCustomer,
    ProductNames = string.Join(", ", order.Products?.Select(item => item.Name) ?? new List<string> { "No products" })
});
productNames.Dump("Tên các sản phẩm trong từng đơn hàng");

//7 Đếm số lượng sản phẩm có giá lớn hơn 500 trong từng đơn hàng. In ra mã đơn hàng, tên khách hàng, và số lượng sản phẩm có giá lớn hơn 500.
var countExpensiveProducts = orders.Select(order => new
{
    order.OrderId,
    order.NameOfCustomer,
    CountExpensiveProducts = order.Products?.Count(item => item.Price > 500) ?? 0
});
countExpensiveProducts.Dump("Số lượng sản phẩm có giá lớn hơn 500 trong từng đơn hàng");
