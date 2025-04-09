Tree tree = new Tree();

//Build tree
int[] values = { 8, 3, 10, 1, 6, 14, 4, 7, 13 };
tree.BuildTreeFromArray(values);

// Count
Console.WriteLine($"The tree has {tree.Count()} nodes in total.");
Console.WriteLine(); 

// Search 
int searchValue = 6;
Node foundNode = tree.FindNode(searchValue);
if (foundNode != null)
{
    Console.WriteLine($"The value {foundNode.Value} exists in the tree.");
}
else
{
    Console.WriteLine($"The value {searchValue} was not found in the tree.");
}
Console.WriteLine(); 

// Find min
Node minNode = tree.FindMin();
if (minNode != null)
{
    Console.WriteLine($"The smallest value is {minNode.Value}.");
}
else
{
    Console.WriteLine("The tree is empty.");
}
Console.WriteLine(); 

// Find max
Node maxNode = tree.FindMax();
if (maxNode != null)
{
    Console.WriteLine($"The largest value is {maxNode.Value}.");
}
else
{
    Console.WriteLine("The tree is empty.");
}
Console.WriteLine(); 

// Cal Height
int height = tree.CalculateHeight();
Console.WriteLine($"The tree's height is {height}");
Console.WriteLine(); 

Console.Write("Values in order: ");
tree.TraverseNLR(tree.Root);
Console.WriteLine(); 
Console.WriteLine(); 

class Tree
{
    public Node Root { get; set; }

    // 1. Count the number of nodes
    public int Count()
    {
        return Count(Root);
    }

    private int Count(Node node)
    {
        if (node == null)
            return 0;
        return 1 + Count(node.Left) + Count(node.Right);
    }

    // 2. Find a node with the given value
    public Node FindNode(int value)
    {
        return FindNode(Root, value);
    }

    private Node FindNode(Node node, int value)
    {
        if (node == null)
            return null;
        if (value == node.Value)
            return node;
        if (value < node.Value)
            return FindNode(node.Left, value);
        return FindNode(node.Right, value);
    }

    // 3. Find the minimum value node
    public Node FindMin()
    {
        if (Root == null)
            return null;
        Node current = Root;
        while (current.Left != null)
        {
            current = current.Left;
        }
        return current;
    }

    // 4. Find the maximum value node
    public Node FindMax()
    {
        if (Root == null)
            return null;
        Node current = Root;
        while (current.Right != null)
        {
            current = current.Right;
        }
        return current;
    }

    // 5. Build tree from an array
    public void BuildTreeFromArray(int[] values)
    {
        Root = null; // Clear the current tree
        foreach (int value in values)
        {
            InsertNode(value);
        }
    }

    // 6. Calculate the height of the tree
    public int CalculateHeight()
    {
        return CalculateHeight(Root);
    }

    private int CalculateHeight(Node node)
    {
        if (node == null)
            return 0;
        int leftHeight = CalculateHeight(node.Left);
        int rightHeight = CalculateHeight(node.Right);
        return 1 + Math.Max(leftHeight, rightHeight);
    }

    // Existing methods (InsertNode, traversals, etc.)
    public void InsertNode(int value)
    {
        if (Root == null)
        {
            Node newNode = new Node(value);
            Root = newNode;
            return;
        }
        AddNodeRecursively(Root, value);
    }

    public void AddNodeRecursively(Node currentNode, int dataOfNewNode)
    {
        if (dataOfNewNode == currentNode.Value)
        {
            throw new Exception("Giá trị Node đã tồn tại trong cây");
        }

        if (dataOfNewNode < currentNode.Value)
        {
            if (currentNode.Left == null)
            {
                Node newNode = new Node(dataOfNewNode);
                currentNode.Left = newNode;
                return;
            }
            AddNodeRecursively(currentNode.Left, dataOfNewNode);
        }
        else
        {
            if (currentNode.Right == null)
            {
                Node newNode = new Node(dataOfNewNode);
                currentNode.Right = newNode;
                return;
            }
            AddNodeRecursively(currentNode.Right, dataOfNewNode);
        }
    }

    public void TraverseNLR(Node node)
    {
        if (node == null)
            return;
        Console.Write(node.Value + " ");
        TraverseNLR(node.Left);
        TraverseNLR(node.Right);
    }

    public void TraverseLNR(Node node)
    {
        if (node == null)
            return;
        TraverseLNR(node.Left);
        Console.Write(node.Value + " ");
        TraverseLNR(node.Right);
    }

    public void TraverseLRN(Node node)
    {
        if (node == null)
            return;
        TraverseLRN(node.Left);
        TraverseLRN(node.Right);
        Console.Write(node.Value + " ");
    }

    public void TraverseRNL(Node node)
    {
        if (node == null)
            return;
        TraverseRNL(node.Right);
        Console.Write(node.Value + " ");
        TraverseRNL(node.Left);
    }

    public void TraverseRLN(Node node)
    {
        if (node == null)
            return;
        TraverseRLN(node.Right);
        TraverseRLN(node.Left);
        Console.Write(node.Value + " ");
    }
}

class Node
{
    public Node(int value)
    {
        Value = value;
    }

    public int Value { get; }
    public Node Left { get; set; }
    public Node Right { get; set; }
}