namespace DeveloperBankCore
{
    public interface IBinarySearchTree
    {
        void Insert(Customer customer);
        Customer Search(int transactionNum);
    }
}