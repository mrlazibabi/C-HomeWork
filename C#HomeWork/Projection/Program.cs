using Dumpify;
using Projection.Classes;

string jsonContent = File.ReadAllText("Products.json");
IEnumerable<Product> products = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Product>>(jsonContent);
//1 get Product Names
IEnumerable<string> productNames = products.Select(p => p.Name);
productNames.Dump("List of product name: ");

//2 get Product Names with Price
IEnumerable<string> productNamesWithPrice = products.Select(p => $"{p.Name} - {p.Price:C}");
productNamesWithPrice.Dump("List of product name with price: ");

//3 get Product Names with Category
IEnumerable<string> productNamesWithCategory = products.Select(p => $"{p.Name} - {p.Category}");
productNamesWithCategory.Dump("List of product name with category: ");

//4 get Product Names with Description
IEnumerable<string> productNamesWithDescription = products.Select(p => $"{p.Name} - {p.Description}");
productNamesWithDescription.Dump("List of product name with description: ");

//5 get Product Names with Release Date
IEnumerable<string> productNamesWithReleaseDate = products.Select(p => $"{p.Name} - {p.ReleaseDate}");
productNamesWithReleaseDate.Dump("List of product name with release date: ");

//6 get Product Names with Manufacturer
IEnumerable<string> productManufacturer = products.Select(p => $"{p.Manufacturer?.Name}");
productManufacturer.Dump("List of product name with manufacturer: ");

//7 8 9 get Product Names with Manufacturer Address
IEnumerable<string> productAddress = products.Select(p => $"{p.Manufacturer.Name} - {p.Manufacturer?.Address?.Street}, {p.Manufacturer?.Address?.City}, {p.Manufacturer?.Address?.Country}");
productAddress.Dump("List of product with manufacturer address: ");

