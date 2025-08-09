using Dumpify;

FilterHelper filterHelper = new FilterHelper();
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
List<string> fruits = new List<string> { "apple", "banana", "cherry", "jackfruit" };

//loc so chan
List<int> isEven = filterHelper.Where(numbers, number => number % 2  == 0);
isEven.Dump("Number that are even: ");

//loc fruit co do dai lon hon 5 
List<string> isGreaterThanFive = filterHelper.Where(fruits, fruit => fruit.Length > 5);
isGreaterThanFive.Dump("Fruit with length greater than 5:");

//loc tu dien, lay gia tien cao hon hoac bang 100000
Dictionary<string, double> books = new Dictionary<string, double>
{
    {"How to love yourself", 1000000},
    {"How to NOT love yourself", 1},
    {"What is coding???", 120000},
    {"Burnout is real!", 10000},
};
List<KeyValuePair<string, double>> checkPrice = filterHelper.Where(books, price => price.Value >= 10000);
checkPrice.Dump("Book with price equal or greater than 10000: ");

class FilterHelper
{
    public List<T> Where<T>(IEnumerable<T> items, Predicate<T> predicate)
    {
        List<T> result = new List<T>();
        foreach (T item in items)
        {
            if (predicate(item))
            {
                result.Add(item);
            }
        }
        return result;
    }
}