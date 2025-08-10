SearchHelper searchHelper = new SearchHelper();
List<int> findEvenNumbers = new List<int> { 2, 3, 5, 7 };
List<int> findOddNumbers = new List<int> { 2, 4, 6, 8 };
List<string> fruits = new List<string> { "apple", "banana", "cherry", "jackfruit" };

// Exist number to be greater than 7
bool isEven = searchHelper.Exist(findEvenNumbers, number => number % 2 == 0);
bool isOdd = searchHelper.Exist(findOddNumbers, number => number % 2 != 0);
Console.WriteLine($"One or more of the numbers \"(2,3,5,7)\" is even : {isEven} ");
Console.WriteLine($"One or more of the numbers \"(2,4,6,8)\" is odd : {isOdd} ");

// Exist fruit to have length greater than 5
bool greaterThanSix = searchHelper.Exist(fruits, fruit => fruit.Length > 6);
Console.WriteLine($"One or more of the fruit have length greater than 6 : {greaterThanSix}");

class SearchHelper
{
    public bool Exist<T>(List<T> items, Predicate<T> predicate)
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