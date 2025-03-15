Algorithms algorithms = new Algorithms();
try
{
    // Bubble Sort
    Console.WriteLine("Bubble Sort");
    int[] arr1 = { 5, 3, 8, 6, 2 };
    algorithms.BubbleSortAsc(arr1);
    Console.WriteLine(string.Join(", ", arr1));
    Console.WriteLine("\n");

    int[] arr2 = { 5, 3, 8, 6, 2 };
    algorithms.BubbleSortDesc(arr2);
    Console.WriteLine(string.Join(", ", arr2));
    Console.WriteLine("\n");

    // Selection Sort
    Console.WriteLine("Selection Sort");
    int[] arr3 = { 5, 3, 8, 6, 2 };
    algorithms.SelectionSortAsc(arr3);
    Console.WriteLine(string.Join(", ", arr3));
    Console.WriteLine("\n");

    int[] arr4 = { 5, 3, 8, 6, 2 };
    algorithms.SelectionSortDesc(arr4);
    Console.WriteLine(string.Join(", ", arr4));
    Console.WriteLine("\n");

    // Merge Sort
    Console.WriteLine("Merge Sort");
    int[] arr5 = { 5, 3, 8, 6, 2 };
    algorithms.MergeSort(arr5, 0, arr5.Length - 1);
    Console.WriteLine(string.Join(", ", arr5));
    Console.WriteLine("\n");

    // Quick Sort
    Console.WriteLine("Quick Sort");
    int[] arr6 = { 5, 3, 8, 6, 2 };
    algorithms.QuickSort(arr6, 0, arr6.Length - 1);
    Console.WriteLine(string.Join(", ", arr6));
    Console.WriteLine("\n");

    // Insertion Sort
    Console.WriteLine("Insertion Sort");
    int[] arr7 = { 5, 3, 8, 6, 2 };
    algorithms.InsertionSortAsc(arr7);
    Console.WriteLine(string.Join(", ", arr7));
    Console.WriteLine("\n");
}
catch (Exception e)
{
    Console.WriteLine($"Message: {e.Message}");
}

public class Algorithms
{
    public void BubbleSortAsc(int[] data)
    {
        if (data is null)
        {
            throw new ArgumentNullException("data is null!");
        }

        int length = data.Length;
        for (int i = 0; i < length - 1; i++)
        {
            bool isSorted = false;
            for (int j = 0; j < length - 1; j++)
            {
                if (data[j] > data[j + 1])
                {
                    int temp = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = temp;
                    isSorted = true;
                }
            }
            if (!isSorted)
            {
                break;
            }
        }
    }

    public void BubbleSortDesc(int[] data)
    {
        if (data is null)
        {
            throw new ArgumentNullException("data is null!");
        }

        int length = data.Length;
        for (int i = 0; i < length - 1; i++)
        {
            bool isSorted = false;
            for (int j = 0; j < length - i - 1; j++)
            {
                if (data[j] < data[j + 1])
                {
                    int temp = data[j];
                    data[j] = data[j + 1];
                    data[j + 1] = temp;
                    isSorted = true;
                }
            }
            if (!isSorted)
            {
                break;
            }
        }
    }
    //========================================================================================================================================//
    public void SelectionSortAsc(int[] data)
    {
        if (data is null)
        {
            throw new ArgumentNullException("data is null!");
        }

        int length = data.Length;
        for (int i = 0; i < length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < length; j++)
            {
                if (data[minIndex] > data[j])
                {
                    minIndex = j;
                }
            }
            int temp = data[minIndex];
            data[minIndex] = data[i];
            data[i] = temp;
        }
    }

    public void SelectionSortDesc(int[] data)
    {
        if (data is null)
        {
            throw new ArgumentNullException("data is null!");
        }

        int length = data.Length;
        for (int i = 0; i < length - 1; i++)
        {
            int maxIndex = i;
            for (int j = i + 1; j < length; j++)
            {
                if (data[maxIndex] < data[j])
                {
                    maxIndex = j;
                }
            }
            int temp = data[maxIndex];
            data[maxIndex] = data[i];
            data[i] = temp;
        }
    }
    //========================================================================================================================================//
    public void MergeSort(int[] data, int left, int right)
    {
        if (left < right) // chia mang thanh 2 nua
        {
            int mid = (left + right) / 2;

            //goi de quy de tiep tuc chia cac mang thanh 1/2
            MergeSort(data, left, mid);
            MergeSort(data, mid + 1, right);

            // gop lai sau khi sort
            Merge(data, left, mid, right);
        }
    }

    private void Merge(int[] data, int left, int mid, int right)
    {
        int n1 = mid - left + 1; // n phan tu array left
        int n2 = right - mid;     // n phan tu array right

        int[] tempLeftArr = new int[n1];
        int[] tempRightArr = new int[n2];

        for (int i = 0; i < n1; i++)
        {
            tempLeftArr[i] = data[left + i]; //sao chep vao mang tam
        }

        for (int j = 0; j < n2; j++)
        {
            tempRightArr[j] = data[mid + 1 + j]; //sao chep vao mang tam
        }

        int leftIndex = 0, rightIndex = 0, l = left;

        while (leftIndex < n1 && rightIndex < n2)
        {
            if (tempLeftArr[leftIndex] <= tempRightArr[rightIndex])
            {
                data[l] = tempLeftArr[leftIndex];
                leftIndex++;
            }
            else
            {
                data[l] = tempRightArr[rightIndex];
                rightIndex++;
            }

            l++;
        }

        while (leftIndex < n1) // sao chep cac phan tu con lai neu van con
        {
            data[l] = tempLeftArr[leftIndex];
            leftIndex++;
            l++;
        }

        while (rightIndex < n2) // sao chep cac phan tu con lai neu van con
        {
            data[l] = tempRightArr[rightIndex];
            rightIndex++;
            l++;
        }
    }
    //========================================================================================================================================//
    public void QuickSort(int[] data, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(data, left, right);

            // sort mang ben trai pivot
            QuickSort(data, left, pivotIndex - 1);
            // sort mang ben phai pivot
            QuickSort(data, pivotIndex + 1, right);
        }
    }

    private int Partition(int[] data, int left, int right)
    {
        int pivot = data[right]; // chon phan tu cuoi lam pivot
        int i = left - 1; // vi tri cua phan tu nho hon pivot

        for (int j = left; j < right; j++)
        {
            if (data[j] <= pivot)
            {
                i++;
                Swap(ref data[i], ref data[j]); // doi cho phan tu nho hon pivot
            }
        }

        Swap(ref data[i + 1], ref data[right]); // tra pivot ve dung vi tri
        return i + 1;
    }

    private void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    //========================================================================================================================================//
    public void InsertionSortAsc(int[] data)
    {
        if (data is null)
        {
            throw new ArgumentNullException("data is null!");
        }

        int length = data.Length;
        for (int i = 1; i < length; i++) // phan tu thu nhat luon coi la da Sorted nen bat dau tu index thu 2, tuc i = data[1]
        {
            int keyIndex = data[i];
            int j = i - 1; // phan tu phia truoc can so sanh

            while (j >= 0 && data[j] > keyIndex) // chuyen phan tu lon hon indexKey sang phai
            {
                data[j + 1] = data[j];
                j--;
            }
            data[j + 1] = keyIndex; //chen indexKey vao vi tri dung 
        }
    }
}