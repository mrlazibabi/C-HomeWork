Tree tree = new Tree();

// Insert the values as per the exercise
int[] values = { 8, 3, 10, 1, 6, 14, 4, 7, 13 };
foreach (int value in values)
{
    tree.InsertNode(value);
}

Console.WriteLine("NLR Traversal:");
tree.TraverseNLR(tree.Root);
Console.WriteLine("\nLNR Traversal:");
tree.TraverseLNR(tree.Root);
Console.WriteLine("\nLRN Traversal:");
tree.TraverseLRN(tree.Root);
Console.WriteLine("\nRNL Traversal:");
tree.TraverseRNL(tree.Root);
Console.WriteLine("\nRLN Traversal:");
tree.TraverseRLN(tree.Root);

class Tree
{
    public Node Root { get; set; }

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