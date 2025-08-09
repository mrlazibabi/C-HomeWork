SearchHelper searchHelper = new SearchHelper();
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
List<string> fruits = new List<string> { "apple", "banana", "cherry", "jackfruit" };

// FirstOrDefault number to be greater than 7
int greaterThanSeven = SearchHelper.FirstOrDefault(numbers, number => number > 7);
int greaterThanNine = SearchHelper.FirstOrDefault(numbers, number => number > 9);
Console.WriteLine($"FirstOrDefault number to be greater than 7 is: {greaterThanSeven} ");
Console.WriteLine($"FirstOrDefault number to be greater than 9 is: {greaterThanNine} ");

// FirstOrDefault book with Price greater than 100000
Dictionary<string, double> books = new Dictionary<string, double>
{
    {"How to love yourself", 1000000},
    {"How to NOT love yourself", 1},
    {"What is coding???", 120000},
    {"Burnout is real!", 10000},
};
KeyValuePair<string, double> expensiveBook = SearchHelper.FirstOrDefault(books, kpv => kpv.Value > 100000);
Console.WriteLine("FirstOrDefault book with Price greater than 100000: " + expensiveBook);

class SearchHelper
{
    public static T FirstOrDefault<T>(IEnumerable<T> items, Predicate<T> predicate)
    {
        T result = default(T);
        foreach (T item in items)
        {
            if (predicate(item))
            {
                result = item;
                return result;
            }
        }
        return default(T);
    }
}