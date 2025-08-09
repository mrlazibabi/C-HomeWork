SearchHelper searchHelper = new SearchHelper();
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
List<string> fruits = new List<string> { "apple", "banana", "cherry", "jackfruit" };

// Single number to be greater than 7
int greaterThanEight = searchHelper.Single(numbers, number => number > 8);
Console.WriteLine($"Single number to be greater than 8 is: {greaterThanEight} ");

// Single fruit to have length greater than 5
string equalFive = searchHelper.Single(fruits, fruit => fruit.Length == 5);
Console.WriteLine($"Single fruit to have length equal than 5 is : {equalFive}");

// Single book with Price greater than 100000
Dictionary<string, double> books = new Dictionary<string, double>
{
    {"How to love yourself", 1000000},
    {"How to NOT love yourself", 1},
    {"What is coding???", 120000},
    {"Burnout is real!", 10000},
};
KeyValuePair<string, double> unrealPrice = searchHelper.Single(books, kpv => kpv.Value == 1);
Console.WriteLine("Single book with Price == 1: " + unrealPrice);

class SearchHelper
{
    public  T Single<T>(IEnumerable<T> items, Predicate<T> predicate)
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
            throw new ArgumentException("Operation Invalid!");
        }
        return onlyOneValid;
    }
}