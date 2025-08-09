SearchHelper searchHelper = new SearchHelper();
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
List<string> fruits = new List<string> { "apple", "banana", "cherry", "jackfruit" };

// LastOrDefault number to be greater than 9
int greaterThanNine = SearchHelper.LastOrDefault(numbers, number => number > 9);
Console.WriteLine($"LastOrDefault number to be greater than 7 is: {greaterThanNine} ");

// LastOrDefault fruit to have length greater than 5
string greaterThanFive = SearchHelper.LastOrDefault(fruits, fruit => fruit.Length > 5);
Console.WriteLine($"LastOrDefault fruit to have length greater than 5 is : {greaterThanFive}");

// LastOrDefault book with Price greater than 100000
Dictionary<string, double> books = new Dictionary<string, double>
{
    {"How to love yourself", 1000000},
    {"How to NOT love yourself", 1},
    {"What is coding???", 120000},
    {"Burnout is real!", 10000},
};
KeyValuePair<string, double> expensiveBook = SearchHelper.LastOrDefault(books, kpv => kpv.Value > 100000);
Console.WriteLine("LastOrDefault book with Price greater than 100000: " + expensiveBook);

class SearchHelper
{
    public static T LastOrDefault<T>(IEnumerable<T> items, Predicate<T> predicate)
    {
        T lastValid = default(T);
        bool found = false;
        foreach (T item in items)
        {
            if (predicate(item))
            {
                lastValid = item;
                found = true;
            }
        }

        if (!found)
        {
            return default;
        }
        return lastValid;
    }
}