using Dumpify;

ListHelper listHelper = new ListHelper();
List<string> fruits = new List<string> { "apple", "banana", "cherry", "jackfruit" };

List<string> skipFirstTwo = fruits.Take(2).ToList();
skipFirstTwo.Dump("List after taking first 2:");


Dictionary<string, double> books = new Dictionary<string, double>
{
    {"How to love yourself", 1000000},
    {"How to NOT love yourself", 1},
    {"What is coding???", 120000},
    {"Burnout is real!", 10000},
};
List<KeyValuePair<string, double>> bookList = books.ToList();
List<KeyValuePair<string, double>> skippedBook = bookList.Take(2).ToList();

skippedBook.Dump($"List after taking first 2:");

class ListHelper
{
    public static List<T> Take<T>(List<T> items, int count)
    {
        List<T> result = new List<T>();

        int takenCount = 0;

        foreach (T item in items)
        {
            if (takenCount < count && items != null)
            {
                result.Add(item);
                takenCount++;
                continue;
            }

            if (takenCount == count )
            {
                break;
            }
        }
        return result;
    }
}