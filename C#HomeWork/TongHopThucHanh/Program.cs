using Newtonsoft.Json;
using Dumpify;
using TongHopThucHanh.Classes;

var jsonContent = File.ReadAllText("MOCK_orders.json");
var orders = JsonConvert.DeserializeObject<List<Order>>(jsonContent);

var q1 = orders
    .Where(o => o.Items.Any(i => i.UnitPrice > 50))
    .Select(o => new { 
        o.OrderNumber,
        CustomerName = $"{o.Customer.FirstName} {o.Customer.LastName}",
        ProductWithReview = o.Items
            .Where(i => i.Reviews != null && i.Reviews.Any())
            .Select(i => i.ProductName)
            .Distinct(),
        TotalQuantity = o.Items.Sum(i => i.Quantity)
    })
    .Where(o => o.TotalQuantity > 20)
    .OrderByDescending(o => o.TotalQuantity);
q1.Dump("Question 1 Results");

var q2 = orders
    .Where(o => o.Payment.PaymentMethod == "Credit Card")
    .Select(o => new {
        o.OrderNumber,
        CustomerName = $"{o.Customer.FirstName} {o.Customer.LastName}",
        TotalValue = o.Items.Sum(i => i.Quantity * i.UnitPrice),
        o.Payment.PaymentMethod,
        HighRatedProducts = o.Items
            .Where(i => i.Reviews != null && i.Reviews.Any(r => r.Rating >= 4))
            .Select(i => i.ProductName)
    })
    .Where(o => o.HighRatedProducts.Count() >= 2 && o.TotalValue > 100000)
    .OrderBy(o => o.CustomerName)
    .ThenByDescending(o => o.TotalValue);
q2.Dump("Question 2 Results");