namespace Lab7BinarySearchTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            BinarySearchTree bst = new BinarySearchTree(20);
            bst.AddRecursive(19);
            bst.AddRecursive(21);
            bst.AddRecursive(22);
            Console.WriteLine(bst.root.Left);
            Console.WriteLine(bst.root.Right);
            Console.WriteLine(bst.root.Right.Right);
            Console.WriteLine();

            Console.WriteLine(bst.SearchIterative(22));
            Console.WriteLine(bst.SearchRecursive(22));
            try
            {
                Console.WriteLine(bst.SearchIterative(23));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                Console.WriteLine(bst.SearchRecursive(23));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
