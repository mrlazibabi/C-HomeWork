using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperBankCore
{
    public class BinarySearchTree : IBinarySearchTree
    {
        private BSTNode root;

        public void Insert(Customer customer)
        {
            root = InsertRec(root, customer);
        }

        private BSTNode InsertRec(BSTNode node, Customer customer)
        {
            if (node == null) return new BSTNode(customer);

            if (customer.TransactionNumber < node.DataOfNode.TransactionNumber)
                node.Left = InsertRec(node.Left, customer);
            else if (customer.TransactionNumber > node.DataOfNode.TransactionNumber)
                node.Right = InsertRec(node.Right, customer);

            return node;
        }

        public Customer Search(int transactionNum)
        {
            return SearchRec(root, transactionNum);
        }

        private Customer SearchRec(BSTNode node, int transactionNum)
        {
            if (node == null) return null;

            if (transactionNum == node.DataOfNode.TransactionNumber)
                return node.DataOfNode;
            else if (transactionNum < node.DataOfNode.TransactionNumber)
                return SearchRec(node.Left, transactionNum);
            else
                return SearchRec(node.Right, transactionNum);
        }
    }

    public class BSTNode
    {
        public Customer DataOfNode { get; set; }
        public BSTNode Right { get; set; }
        public BSTNode Left { get; set; }

        public BSTNode(Customer data)
        {
            DataOfNode = data;
            Left = null;
            Right = null;
        }
    }
}
