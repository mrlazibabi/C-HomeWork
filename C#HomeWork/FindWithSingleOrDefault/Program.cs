SearchHelper searchHelper = new SearchHelper();
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
List<string> fruits = new List<string> { "apple", "banana", "cherry", "jackfruit" };

// SingleOrDefault number to be greater than 7
int greaterThanFive = searchHelper.SingleOrDefault(numbers, number => number > 5);
Console.WriteLine($"SingleOrDefault number to be greater than 8 is: {greaterThanFive} ");

// SingleOrDefault fruit to have length greater than 5
string equalSix = searchHelper.SingleOrDefault(fruits, fruit => fruit.Length == 6);
Console.WriteLine($"SingleOrDefault fruit to have length equal 6 is : {equalSix}");

// SingleOrDefault book with Price greater than 100000
Dictionary<string, double> books = new Dictionary<string, double>
{
    {"How to love yourself", 1000000},
    {"How to NOT love yourself", 1},
    {"What is coding???", 120000},
    {"Burnout is real!", 10000},
};
KeyValuePair<string, double> unrealPrice = searchHelper.SingleOrDefault(books, kpv => kpv.Value == 1);
Console.WriteLine("SingleOrDefault book with Price == 1: " + unrealPrice);

class SearchHelper
{
    public T SingleOrDefault<T>(IEnumerable<T> items, Predicate<T> predicate)
    {
        T onlyOneValid = default(T);
        int count = 0;
        foreach (T item in items)
        {
            if (predicate(item))
            {
                onlyOneValid = item;
                count++;
            }
        }

        if (count > 1)
        {
            return default;
        }
        return onlyOneValid;
    }
}