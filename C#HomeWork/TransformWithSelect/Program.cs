using Dumpify;
using System.Reflection.Metadata.Ecma335;

TransformHelper transformHelper = new TransformHelper();
List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
List<string> fruits = new List<string> { "apple", "banana", "cherry", "jackfruit" };

//chuyen sang EVEN neu la so chan va nguoc lai
List<string> transformNumber = transformHelper.Select(numbers, number =>
{
    return number % 2 == 0 ? "EVEN" : "ODD";
});
transformNumber.Dump("Transform list numbers {1,2,3,4,5,6,7,8,9} : ");

//chinh sua tu dien, tang gia tien * 2 
Dictionary<string, double> books = new Dictionary<string, double>
{
    {"How to love yourself", 1000000},
    {"How to NOT love yourself", 1},
    {"What is coding???", 120000},
    {"Burnout is real!", 10000},
};
List<KeyValuePair<string, double>> doublePrice = transformHelper.Select(books, price => new KeyValuePair<string, double>(price.Key, price.Value * 2));
doublePrice.Dump("Book with doubled price: ");

class TransformHelper
{
    public List<TResult> Select<T, TResult>(IEnumerable<T> items, Func<T, TResult> transform)
    {
        List<TResult> result = new List<TResult>();
        foreach (T item in items)
        {
            result.Add(transform(item));
        }
        return result;
    }
}