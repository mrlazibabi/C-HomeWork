SearchHelper searchHelper = new SearchHelper();
List<int> numbers = new List<int> { 2, 4, 6, 8 };
List<string> fruits = new List<string> { "apple", "banana", "cherry", "jackfruit" };

// All number to be greater than 7
bool isEven = searchHelper.All(numbers, number => number % 2 == 0);
Console.WriteLine($"All number is even : {isEven} ");

// All fruit to have length greater than 5
bool greaterThanSix = searchHelper.All(fruits, fruit => fruit.Length > 6);
Console.WriteLine($"All fruit have length greater than 6 : {greaterThanSix}");

// All book with Price greater than 100000
Dictionary<string, double> books = new Dictionary<string, double>
{
    {"How to love yourself", 1000000},
    {"How to NOT love yourself", 1},
    {"What is coding???", 120000},
    {"Burnout is real!", 10000},
};
bool allPriceGreaterThanOne = searchHelper.All(books, kpv => kpv.Value > 1);
Console.WriteLine("All book with Price > 1: " + allPriceGreaterThanOne);

class SearchHelper
{
    public bool All<T>(IEnumerable<T> items, Predicate<T> predicate)
    {
        foreach (T item in items)
        {
            if (!predicate(item))
            {
                return false;           
            }
        }
        return true;
    }
}