using Dumpify;
using Projection.Classes;

string jsonContent = File.ReadAllText("Products.json");
IEnumerable<Product> products = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<Product>>(jsonContent);
//1 Get Product Names and Price where Price > 100
IEnumerable<object> productsPriceGreaterThan100 = products
    .Where(p => p.Price > 100)
    .Select(p => new { p.Name, p.Price });
productsPriceGreaterThan100.Dump("Products with Price > 100");

//2 Get Product Names where Name containing letter 'a'
IEnumerable<object> productsWithNameContainingA = products
    .Where(p => p.Name.Contains('a', StringComparison.OrdinalIgnoreCase))
    .Select(p => new { p.Name });
productsWithNameContainingA.Dump("Products with Name containing 'a'");

//3 Get Product Names and Stock where Stock > 500
IEnumerable<object> productsWithStockGreaterThan500 = products
    .Where(p => p.Stock > 500)
    .Select(p => new { p.Name, p.Stock });
productsWithStockGreaterThan500.Dump("Products with Stock > 500");

//4 Get Product Names and Release Date where Release Date after 2016
IEnumerable<object> productsReleasedAfter2016 = products
    .Where(p => DateTime.Parse(p.ReleaseDate).Year > 2016)
    .Select(p => new { p.Name, p.ReleaseDate });
productsReleasedAfter2016.Dump("Products released after 2016");

//5 Get Product Names and Prices where Price between 50 and 200
IEnumerable<object> productsWithPriceBetween50And200 = products
    .Where(p => p.Price >= 50 && p.Price <= 200)
    .Select(p => new { p.Name, p.Price });
productsWithPriceBetween50And200.Dump("Products with Price between 50 and 200");

//6 Get Product Names and Prices where Category is 'Clothing'
IEnumerable<object> clothingProducts = products
    .Where(p => p.Category.Equals("Clothing", StringComparison.OrdinalIgnoreCase))
    .Select(p => new { p.Name, p.Price });
clothingProducts.Dump("Clothing Products");

//7 Get Product Names and Stock where Stock < 100
IEnumerable<object> productsWithStockLessThan100 = products
    .Where(p => p.Stock < 100)
    .Select(p => new { p.Name, p.Stock });
productsWithStockLessThan100.Dump("Products with Stock < 100");

//8 Get Product Names and Release Date where Release Date before 2015
IEnumerable<object> productsReleasedBefore2015 = products
    .Where(p => DateTime.Parse(p.ReleaseDate).Year < 2015)
    .Select(p => new { p.Name, p.ReleaseDate });
productsReleasedBefore2015.Dump("Products released before 2015");

//9 Get Product Names, Prices and manufacturer Name where Price > 200 and manufacturer Name start with 'Y' 
IEnumerable<object> productsWithPriceGreaterThan200AndManufacturerY = products
    .Where(p => p.Price > 200 && p.Manufacturer.Name.StartsWith("Y", StringComparison.OrdinalIgnoreCase))
    .Select(p => new { p.Name, p.Price, ManufacturerName = p.Manufacturer.Name });
productsWithPriceGreaterThan200AndManufacturerY.Dump("Products with Price > 200 and Manufacturer Name starts with 'Y'");

//10 Get Product Names, Prices and Categories where Category is 'Electronics' and Price < 300
IEnumerable<object> electronicsProductsWithPriceLessThan300 = products
    .Where(p => p.Category.Equals("Electronics", StringComparison.OrdinalIgnoreCase) && p.Price < 300)
    .Select(p => new { p.Name, p.Price, p.Category });
electronicsProductsWithPriceLessThan300.Dump("Electronics Products with Price < 300");

//11 Get Product Names and Descriptions where Name containing 'Laptop'
IEnumerable<object> productsWithNameContainingLaptop = products
    .Where(p => p.Name.Contains("Laptop", StringComparison.OrdinalIgnoreCase))
    .Select(p => new { p.Name, p.Description });
productsWithNameContainingLaptop.Dump("Products with Name containing 'Laptop'");

//12 Get Product Names, Prices and manufature Name where Price between 100 and 500
IEnumerable<object> productsWithPriceBetween100And500 = products
    .Where(p => p.Price >= 100 && p.Price <= 500)
    .Select(p => new { p.Name, p.Price, ManufacturerName = p.Manufacturer.Name });
productsWithPriceBetween100And500.Dump("Products with Price between 100 and 500");

//13 Get Product Names and manufacturer Name where Category is 'Clothing' and manufacturer Name is 'Yamia'
IEnumerable<object> clothingProductsByManufacturerYamia = products
    .Where(p => p.Category.Equals("Clothing", StringComparison.OrdinalIgnoreCase) && p.Manufacturer.Name.Equals("Yamia", StringComparison.OrdinalIgnoreCase))
    .Select(p => new { p.Name, ManufacturerName = p.Manufacturer.Name });
clothingProductsByManufacturerYamia.Dump("Clothing Products by Manufacturer 'Yamia'");

//14 Get Product Names, Stocks and Categories where Stock > 500
IEnumerable<object> productsWithStockGreaterThan500AndCategories = products
    .Where(p => p.Stock > 500)
    .Select(p => new { p.Name, p.Stock, p.Category });
productsWithStockGreaterThan500AndCategories.Dump("Products with Stock > 500 and their Categories");

//15 Get Products Names, Prices and Release Dates where Release Date is in 2020
IEnumerable<object> productsReleasedIn2020 = products
    .Where(p => DateTime.Parse(p.ReleaseDate).Year == 2020)
    .Select(p => new { p.Name, p.Price, p.ReleaseDate });
productsReleasedIn2020.Dump("Products released in 2020");