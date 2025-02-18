FindMaxCheck z = new FindMaxCheck();
Console.WriteLine(z.FindMax([5, 2, 8, 3, 9]));
Console.WriteLine(z.FindMax([10, 20, 30, 40]));
Console.WriteLine(z.FindMax([1, 2, 3, 4, 5]));

public class FindMaxCheck
{
    public int FindMax(int[] arr, int index = -1)
    {

        if (index == -1)
        {
            index = arr.Length - 1;
        }

        if (index == 0) //base case
        {
            return arr[0];
        }

        int currentIndex = FindMax(arr, index - 1);

        return Math.Max(currentIndex, arr[index]);
    }
}

