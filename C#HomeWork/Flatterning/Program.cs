using Dumpify;
using Flatterning.Classes;

Console.OutputEncoding = System.Text.Encoding.UTF8;
var jsonContent = File.ReadAllText("orders-with-review.json");
var orders = System.Text.Json.JsonSerializer.Deserialize<List<Order>>(jsonContent);


var flattenedProducts = orders?
    .SelectMany(order => order.Customer.Items, (order, item) => new
    {
        order.OrderNumber,
        item.ProductName,
        item.UnitPrice,
        item.Quantity,
        TotalPrice = item.UnitPrice * item.Quantity
    });
flattenedProducts.Dump();