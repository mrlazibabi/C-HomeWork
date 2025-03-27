using MyCustomList;

CustomList MCList = new CustomList(0);

try
{
    // Add elements
    Console.WriteLine("\nAdding numbers: 10, 20, 30");
    MCList.Add(10);
    MCList.Add(20);
    MCList.Add(30);
    PrintList(MCList);

    // Insert at index
    Console.WriteLine("\nInserting number 15 at index 1");
    MCList.Insert(1, 15);
    PrintList(MCList);

    // Check existence
    Console.WriteLine("\nIs number 20 in the list?");
    if (MCList.Contains(20))
    {
        Console.WriteLine("Yes, number 20 exists in the list.");
    }
    else
    {
        Console.WriteLine("No, number 20 is not in the list.");
    }

    Console.WriteLine("\nIs number 50 in the list?");
    if (MCList.Contains(50))
    {
        Console.WriteLine("Yes, number 50 exists in the list.");
    }
    else
    {
        Console.WriteLine("No, number 50 is not in the list.");
    }

    // Search
    Console.WriteLine("\nFirst occurrence of 20: " + MCList.IndexOf(20));
    Console.WriteLine("Last occurrence of 20: " + MCList.LastIndexOf(20));

    // Remove element
    Console.WriteLine("\nRemoving number 15 from the list");
    MCList.Remove(15);
    PrintList(MCList);

    // Remove by index
    Console.WriteLine("\nRemoving element at index 1");
    MCList.RemoveAt(1);
    PrintList(MCList);

    // Check if the list is empty before clearing
    Console.WriteLine("\nIs the list empty?");
    if (MCList.IsEmpty())
    {
        Console.WriteLine("Yes, the list is empty.");
    }
    else
    {
        Console.WriteLine("No, the list still has elements.");
    }

    // Clear list
    Console.WriteLine("\nClearing the entire list...");
    MCList.Clear();
    PrintList(MCList);

    // Check if the list is empty after clearing
    Console.WriteLine("\nIs the list empty after clearing?");
    if (MCList.IsEmpty())
    {
        Console.WriteLine("Yes, the list is empty after clearing.");
    }
    else
    {
        Console.WriteLine("No, the list still has elements (there may be an issue with the Clear() method).");
    }
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine("Index error: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Unexpected error: " + ex.Message);
}

static void PrintList(CustomList list)
{
    Console.WriteLine("Elements in the list: [" + string.Join(", ", list.ToArray()) + "]");
    Console.WriteLine("Total number of elements: " + list.Count);
}
