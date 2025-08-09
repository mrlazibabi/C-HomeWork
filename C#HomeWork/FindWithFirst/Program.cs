using Dumpify;

SearchHelper searchHelper = new SearchHelper();
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
List<string> fruits = new List<string> { "apple", "banana", "cherry", "jackfruit" };

// First number to be greater than 7
int greaterThanSeven = SearchHelper.First(numbers, number => number > 7);
Console.WriteLine($"First number to be greater than 7 is: {greaterThanSeven} ");

// First book with Price greater than 100000
Dictionary<string, double> books = new Dictionary<string, double>
{
    {"How to love yourself", 1000000},
    {"How to NOT love yourself", 1},
    {"What is coding???", 120000},
    {"Burnout is real!", 10000},
};
KeyValuePair<string, double> expensiveBook = SearchHelper.First(books, kpv => kpv.Value > 100000);
Console.WriteLine("First book with Price greater than 100000: " + expensiveBook);

class SearchHelper
{
    public static T First<T>(IEnumerable<T> items, Predicate<T> predicate)
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
        throw new ArgumentException("Operation Invalid");
    }
}