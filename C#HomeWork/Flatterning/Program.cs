using Dumpify;
using Flatterning.Classes;

Console.OutputEncoding = System.Text.Encoding.UTF8;
var jsonContent = File.ReadAllText("orders-with-review.json");
var orders = System.Text.Json.JsonSerializer.Deserialize<List<Order>>(jsonContent);

var totalValueOfProduct = orders?
    .Select(order => new
    {
        order.OrderNumber,
        FullName = $"{order.Customer.FirstName} {order.Customer.LastName}",
        Address = $"{order.Customer.Address.Street}, {order.Customer.Address.City}",
        order.Customer.Phone,
        TotalOrderValue = order.Customer.Items.Sum(item => item.UnitPrice * item.Quantity)
    });
totalValueOfProduct.Dump();