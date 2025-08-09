SearchHelper searchHelper = new SearchHelper();
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
List<string> fruits = new List<string> { "apple", "banana", "cherry", "jackfruit" };

// Last number to be greater than 7
int greaterThanSeven = SearchHelper.Last(numbers, number => number > 7);
Console.WriteLine($"Last number to be greater than 7 is: {greaterThanSeven} ");

// Last fruit to have length greater than 5
string greaterThanFive = SearchHelper.Last(fruits, fruit => fruit.Length > 5);
Console.WriteLine($"Last fruit to have length greater than 5 is : {greaterThanFive}");

// Last book with Price greater than 100000
Dictionary<string, double> books = new Dictionary<string, double>
{
    {"How to love yourself", 1000000},
    {"How to NOT love yourself", 1},
    {"What is coding???", 120000},
    {"Burnout is real!", 10000},
};
KeyValuePair<string, double> expensiveBook = SearchHelper.Last(books, kpv => kpv.Value > 100000);
Console.WriteLine("Last book with Price greater than 100000: " + expensiveBook);

class SearchHelper
{
    public static T Last<T>(IEnumerable<T> items, Predicate<T> predicate)
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
            throw new ArgumentException("Operation Invalid!");
        }
        return lastValid;
    }
}