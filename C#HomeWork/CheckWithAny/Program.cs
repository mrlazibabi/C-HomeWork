SearchHelper searchHelper = new SearchHelper();
List<int> findEvenNumbers = new List<int> { 2, 4, 5, 7 };
List<int> findOddNumbers = new List<int> { 2, 4, 6, 8 };
List<string> fruits = new List<string> { "apple", "banana", "cherry", "jackfruit" };

// Any number to be greater than 7
bool isEven = searchHelper.Any(findEvenNumbers, number => number % 2 == 0);
bool isOdd = searchHelper.Any(findOddNumbers, number => number % 2 != 0);
Console.WriteLine($"One or more of the numbers \"(2,4,5,7)\" is even : {isEven} ");
Console.WriteLine($"One or more of the numbers \"(2,4,6,8)\" is odd : {isOdd} ");

// Any fruit to have length greater than 5
bool greaterThanSix = searchHelper.Any(fruits, fruit => fruit.Length > 6);
Console.WriteLine($"One or more of the fruit have length greater than 6 : {greaterThanSix}");

// Any book with Price greater than 100000
Dictionary<string, double> books = new Dictionary<string, double>
{
    {"How to love yourself", 1000000},
    {"How to NOT love yourself", 1},
    {"What is coding???", 120000},
    {"Burnout is real!", 10000},
};
bool allPriceGreaterThanOne = searchHelper.Any(books, kpv => kpv.Value > 1);
Console.WriteLine("Any book with Price > 1: " + allPriceGreaterThanOne);

class SearchHelper
{
    public bool Any<T>(IEnumerable<T> items, Predicate<T> predicate)
    {
        foreach (T item in items)
        {
            if (predicate(item))
            {
                return true;
            }
        }
        return false;
    }
}